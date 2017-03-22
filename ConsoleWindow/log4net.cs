using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWindow
{
    public static class log4netInit
    {
        private static string xml = @"
<?xml version=""1.0"" encoding=""utf-8"" ?> 
<log4net>
  <appender name = ""Console"" type=""ConsoleWindow.ConsoleOutput"">
    <mapping>
      <level value = ""ERROR"" />
      < foreColor value=""White"" />
      <backColor value = ""Red, HighIntensity"" />
    </ mapping >
    < mapping >
      < level value=""DEBUG"" />
      <backColor value = ""Green"" />
    </ mapping >
    < layout type=""log4net.Layout.PatternLayout"">
      <conversionPattern value = ""[%date] [%thread] [%-5level] [%logger]: %message%newline"" />
    </ layout >
  </ appender >


  < appender name=""RollingFile"" type=""log4net.Appender.RollingFileAppender"">
    <file value = ""example.log"" />
    < appendToFile value=""true"" />
    <maximumFileSize value = ""100KB"" />
    < maxSizeRollBackups value=""2"" />

    <layout type = ""log4net.Layout.PatternLayout"" >
      < conversionPattern value=""[%date] [%thread] [%-5level] [%logger]: %message%newline"" />
    </layout>
  </appender>
    
  <root>
    <level value = ""DEBUG"" />
    < appender -ref ref=""Console"" />
    <appender-ref ref=""RollingFile"" />
  </root>
</log4net>
";

        static log4netInit()
        {
            //log4net.Config.XmlConfigurator.Configure(xml.ToStream().BaseStream);
        }

        public static string lel = "";

    }
}
