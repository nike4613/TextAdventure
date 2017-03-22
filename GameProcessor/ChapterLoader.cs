using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Util;
using System.Reflection;
using log4net;

namespace GameProcessor
{

    public class ChapterLoader
    {

        public static void Test()
        {
            Chapter ch = LoadChapter(Properties.Resources.prologue.ToStream());

            log.Debug(ch);
        }

        delegate void TextBlockDone(string tb);

        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public static Chapter LoadChapter(StreamReader stream)
        {
            Chapter chapter = new Chapter();

            AChapterConfigElement current = null;

            string textBlock = "";
            TextBlockDone tbdon = (string s) =>
            {
                if (current != null) current.SetTextBlock(s);
            };

            string line;
            while ((line = stream.ReadLine()) != null)
            {

                if (line.StartsWith("#")) continue;

                StreamReader s = line.ToStream();

                int pos = 0;

                string cstr = "";
                string cqstr = "";

                bool inSqr = false;
                bool hasSq = false;
                bool inQ = false;
                bool inSqg = false;

                ObjectType ctyp = new ObjectType();
                string propn = "";
                List<string> args = new List<string>();
                string propv = "";

                char c = (char)0;
                while (!s.EndOfStream)
                {
                    c = (char)s.Read();

                    if (hasSq)
                    {
                        if (c == ':' && inSqr)
                        {
                            ctyp = ObjectTypeMethods.FromName(cstr);
                            cstr = "";
                        }
                        else if (!inSqr && c == '=')
                        {
                            propv = line.Substring(pos + 1);
                        }
                        else if (c == '"' && inSqr)
                        {
                            inQ = !inQ;
                            if (inQ)
                            {
                                cqstr = "";
                            }
                            else
                            {
                                args.Add(cqstr);
                            }
                        }
                        else if (inQ)
                        {
                            cqstr += c;
                        }
                        else if (c == ']' && inSqr)
                        {
                            inSqr = false;
                            propn = cstr;
                        }
                        else
                        {
                            cstr += c;
                        }

                    }
                    else if (inSqg)
                    {
                        // Ignore for now
                    }
                    else
                    {
                        if (! ( pos == 0 && (c == '[' || c == '{')))
                            textBlock += c;
                    }


                    if (pos == 0)
                    {
                        switch (c)
                        {
                            case '[': // Data header
                                tbdon(textBlock);
                                textBlock = "";
                                inSqr = true;
                                hasSq = true;
                                break;
                            case '{': // Instruction header
                                tbdon(textBlock);
                                textBlock = "";
                                inSqg = true;
                                break;
                        }
                    }

                    pos++;
                    
                }

                if (hasSq)
                {
                    log.DebugFormat("type: {0}, propn: '{1}', value: '{2}', args: '{3}'", ctyp, propn, propv, string.Join("','",args));

                    if (propn == "" && args.Count == 1)
                    {
                        current = (AChapterConfigElement)Activator.CreateInstance(ctyp.GetReprType());
                        current.Chapter = chapter;
                    }

                    current.SetProperty(propn, args.ToArray(), propv);

                }

            }

            tbdon(textBlock);

            return chapter;
        }

    }
}
