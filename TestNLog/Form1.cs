using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using NLog;
using NLog.Targets;
using NLog.Config;
using NLog.Targets.Wrappers;


namespace TestNLog
{

    /************************************************************************/
    /* NLog输出方式：
     * 文件
     * 窗体控件
     * console
     * 邮箱
     * 系统日志
     * 数据库
     * MessageBox
    
    /************************************************************************/
    public partial class Form1 : Form
    {
        //日志窗口
          Form_Log formLog2 = new Form_Log();    
        Form_Log formLog = new Form_Log();


        public Form1()
        {
            InitializeComponent();
            formLog.Text += "1";
            formLog2.Text += "2";
            this.formLog2.Show(); 
            this.formLog.Show();

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            LoggingConfiguration Config = new LoggingConfiguration();

            //输出到控制台（调试输出）
            ColoredConsoleTarget consoleTarget = new ColoredConsoleTarget();
            consoleTarget.Layout = @"${date:format=HH\:mm\:ss} ${logger} ${message}";
            Config.AddTarget("console", consoleTarget);
            LoggingRule rule1 = new LoggingRule("*", LogLevel.Debug, consoleTarget);
            Config.LoggingRules.Add(rule1);

            //输出到文本文件
            FileTarget fileTarget = new FileTarget();
            fileTarget.FileName = "${basedir}/file.txt";
            fileTarget.Layout = @"[${date:format=yyyy-MM-dd HH\:mm\:ss}][${logger}][${level}] ${message} ${exception}";
            Config.AddTarget("file", fileTarget);
            LoggingRule rule2 = new LoggingRule("*", LogLevel.Debug, fileTarget);
            Config.LoggingRules.Add(rule2);

            //输出到窗体控件
            FormControlTarget formTarget = new FormControlTarget();
            formTarget.FormName = "Form_Log"; //窗口类名，如果有多个窗体，默认选择输出到第一个show的窗体
            formTarget.ControlName = "richTextBoxEx1";//窗口中的控件名
            formTarget.Layout = @"[${longdate}][${callsite}][${level}][${logger}] ${message} ${exception} ${newline}"; //必须手动添加换行符
            formTarget.Append = true;
            Config.AddTarget("control", formTarget);
            LoggingRule rule3 = new LoggingRule("*", LogLevel.Debug, formTarget);
            Config.LoggingRules.Add(rule3);

            //输出到邮箱
            MailTarget mailTarget = new MailTarget();
            BufferingTargetWrapper buffer = new BufferingTargetWrapper(mailTarget, 5);
            mailTarget.SmtpServer = "smtp.gmail.com";
            mailTarget.SmtpPort = 587;
            mailTarget.SmtpAuthentication = SmtpAuthenticationMode.Basic;
            mailTarget.SmtpUserName = "xjtsir@gmail.com";
            mailTarget.SmtpPassword = "200000";
            mailTarget.EnableSsl = true;
            mailTarget.From = "xjtsir@gmail.com";
            mailTarget.To = "435400337@qq.com";
            mailTarget.CC = "xjt1972@163.net;xjtsir@gmail.com";//抄送CC 暗抄送BCC
            mailTarget.Subject = "NLOG开发文档";
            mailTarget.Body =@"[${date:format=yyyy-MM-dd HH\:mm\:ss}][${logger}][${level}]${message}${newline}";
            mailTarget.AddNewLines = true;

            //Config.AddTarget("mail", mailTarget);

            //LoggingRule rule4 = new LoggingRule("*", LogLevel.Fatal, mailTarget);//仅仅关键的日志才输出到邮箱
            //Config.LoggingRules.Add(rule4);

            //LogFactory factory = new LogFactory();
            //factory.Configuration = Config;
            SimpleConfigurator.ConfigureForTargetLogging(buffer,LogLevel.Fatal);

              
            LogManager.Configuration = Config;

        
         Logger logger = LogManager.GetLogger("运行日志");
         //    Logger logger = LogManager.GetCurrentClassLogger();

            logger.Trace("trace log message");
            logger.Debug("debug log message");
            logger.Debug("AAAAAAAAAAAAAAA debug log message");
            logger.Info("info log message");
            logger.Warn("warn log message");
            logger.Error("error log message");
            logger.Fatal("1fatal log message");
            logger.Fatal("2fatal log message");
            logger.Fatal("3fatal log message");
            logger.Fatal("4fatal log message");
            logger.Fatal("5fatal log message");
            logger.Fatal("6fatal log message");
            logger.Fatal("7fatal log message");
            logger.Fatal("8fatal log message");




        }

        //邮箱测试通过
        private void buttonX2_Click(object sender, EventArgs e)
        {
            LoggingConfiguration config = new LoggingConfiguration();

            MailTarget mailTarget = new MailTarget();
            BufferingTargetWrapper buffer = new BufferingTargetWrapper(mailTarget, 50);
            


            mailTarget.SmtpServer = "smtp.163.net";
            mailTarget.SmtpUserName = "xjt1972@163.net";
            mailTarget.SmtpPassword = "197275";
            mailTarget.From = "xjt1972@163.net";
            mailTarget.To = "435400337@qq.com";
            mailTarget.Subject = DateTime.Today.ToShortDateString()+"日会议纪要";
            mailTarget.Body = @"[${date:format=yyyy-MM-dd HH\:mm\:ss}][${logger}][${level}]${message}${newline}";
       
            mailTarget.SmtpPort = 25;
            mailTarget.SmtpAuthentication = SmtpAuthenticationMode.Basic;   
            mailTarget.EnableSsl = false;     
            //mailTarget.CC = "435400337@qq.com";//抄送CC 暗抄送BCC
            // mailTarget.AddNewLines = true;
        
            Console.WriteLine("Sending...");

            NLog.Config.SimpleConfigurator.ConfigureForTargetLogging(buffer,LogLevel.Fatal);
            Logger logger = LogManager.GetLogger("Example");

            //config.AddTarget("email", mailTarget);
            //config.LoggingRules.Add(new LoggingRule("*", LogLevel.Fatal,buffer));
            //LogFactory factory = new LogFactory();
            //factory.Configuration = config;
            //Logger logger = factory.GetLogger("Example");

            //logger.Trace("trace log message");
            //logger.Debug("debug log message");
            //logger.Debug("AAAAAAAAAAAAAAA debug log message");
            //logger.Info("info log message");
            //logger.Warn("warn log message");
            //logger.Error("error log message");     
            logger.Fatal("log message 1");
            logger.Fatal("log message 2");
            logger.Fatal("log message 3");
            logger.Fatal("log message 4");
            logger.Fatal("log message 5");
            logger.Fatal("log message 6");
            logger.Fatal("log message 7");
            logger.Fatal("log message 8");
            // this should send 2 mails - one with messages 1..5, the other
            Console.WriteLine("Sent.");
        }
    }
}
