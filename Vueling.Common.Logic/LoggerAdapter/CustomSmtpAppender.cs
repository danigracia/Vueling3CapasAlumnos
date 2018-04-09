using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Reflection;
using System.Linq;
using System.Text;
using log4net.Core;
using System.Web;
using System.Threading.Tasks;

namespace Vueling.Common.Logic.LoggerAdapter
{

    /*
     * 
     * 
     * 
    /// <summary>
    /// This Class is Creating a custom log4net appender
    /// </summary>
    public class CustomSmtpAppender : log4net.Appender.BufferingAppenderSkeleton
    {
        #region SmtpAuthentication Enum
        /// <summary>
        /// Values for the <see cref="CustomSmtpAppender.Authentication" /> property.
        /// </summary>
        /// <remarks>
        /// SMTP authentication modes.
        /// </remarks>
        public enum AuthenticationSmtp
        {
            /// <summary>
            /// No authentication
            /// </summary>
            None,

            /// <summary>
            /// Basic authentication.
            /// </summary>
            /// <remarks>
            /// Requires a username and password to be supplied
            /// </remarks>
            Basic,

            /// <summary>
            /// Integrated authentication
            /// </summary>
            /// <remarks>
            /// Uses the Windows credentials from the current thread or process to authenticate.
            /// </remarks>
            Ntlm
        }
        #endregion /// SmtpAuthentication Enum

        #region Private Instance Fields
        private string enableEmailSent;
        private string to;
        private string from;
        private string subject;
        private string smtpHost;
        private string smtpAuthentication;
        private string enableSsl;
        private string userName;
        private string password;
        private string smtpPort; /// server port, default port 25       
        private MailPriority mailPriority = MailPriority.Normal;
        private string projectName;
        #endregion /// Private Instance Fields

        #region Constructors

        /// <summary>
        /// Default Constructors
        /// Initializes a new instance of the <see cref="CustomSmtpAppender" /> class.
        /// </summary>
        public CustomSmtpAppender() : base()
        {
        }
        #endregion /// Public Instance Constructors

        #region Public Properties
        /// <summary>
        /// Gets or sets the enable email sent.
        /// </summary>
        /// <value>
        /// The enable email sent.
        /// </value>
        public string EnableEmailSent
        {
            set
            {
                this.enableEmailSent = value;
            }
            get
            {
                return this.enableEmailSent;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is enable email sent.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is enable email sent; otherwise, <c>false</c>.
        /// </value>
        public bool IsEmailSentEnable
        {
            get
            {
                bool isEmailSentEnable;
                bool.TryParse(EnableEmailSent.ToLower() ?? "false", out isEmailSentEnable);
                return isEmailSentEnable;
            }
        }

        /// <summary>
        /// Gets or sets a semicolon-delimited list of recipient e-mail addresses.
        /// </summary>
        /// <value>
        /// A semicolon-delimited list of e-mail addresses.
        /// </value>
        /// <remarks>
        /// <para>
        /// A semicolon-delimited list of recipient e-mail addresses.
        /// </para>
        /// </remarks>
        public string To
        {
            get
            {
                return this.to;
            }
            set
            {
                this.to = value;
            }
        }

        /// <summary>
        /// Gets or sets the e-mail address of the sender.
        /// </summary>
        /// <value>
        /// The e-mail address of the sender.
        /// </value>
        /// <remarks>
        /// <para>
        /// The e-mail address of the sender.
        /// </para>
        /// </remarks>
        public string From
        {
            get
            {
                return this.from;
            }
            set
            {
                this.from = value;
            }
        }

        /// <summary>
        /// Gets or sets the subject line of the e-mail message.
        /// </summary>
        /// <value>
        /// The subject line of the e-mail message.
        /// </value>
        /// <remarks>
        /// <para>
        /// The subject line of the e-mail message.
        /// </para>
        /// </remarks>
        public string Subject
        {
            get
            {
                return this.subject;
            }
            set
            {
                this.subject = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the SMTP relay mail server to use to send 
        /// the e-mail messages.
        /// </summary>
        /// <value>
        /// The name of the e-mail relay server. If SmtpServer is not set, the 
        /// name of the local SMTP server is used.
        /// </value>
        /// <remarks>
        /// <para>
        /// The name of the e-mail relay server. If SmtpServer is not set, the 
        /// name of the local SMTP server is used.
        /// </para>
        /// </remarks>
        public string SmtpHost
        {
            get
            {
                return this.smtpHost;
            }
            set
            {
                this.smtpHost = value;
            }
        }

        /// <summary>
        /// The port on which the SMTP server is listening
        /// </summary>
        /// <remarks>
        /// <note type="caution">Server Port is only available on the MS .NET 1.1 runtime.</note>
        /// <para>
        /// The port on which the SMTP server is listening. The default
        /// port is <c>25</c>. The Port can only be changed when running on
        /// the MS .NET 1.1 runtime.
        /// </para>
        /// </remarks>
        public string SmtpPort
        {
            get
            {
                return this.smtpPort;
            }
            set
            {
                this.smtpPort = value;
            }
        }

        /// <summary>
        /// Gets the SMTP port.
        /// </summary>
        /// <value>
        /// The port.
        /// </value>
        public int Port
        {
            get
            {
                int intPort;
                int.TryParse(smtpPort ?? "25", out intPort);
                return intPort;
            }
        }

        /// <summary>
        /// Gets or sets the enable SSL.
        /// </summary>
        /// <value>
        /// The enable SSL.
        /// </value>
        public string EnableSsl
        {
            get
            {
                return enableSsl;
            }
            set
            {
                enableSsl = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is SSL enable.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is SSL enable; otherwise, <c>false</c>.
        /// </value>
        public bool IsSslEnable
        {
            get
            {
                bool isSslEnable;
                bool.TryParse(EnableSsl.ToLower() ?? "false", out isSslEnable);
                return isSslEnable;
            }
        }

        /// <summary>
        /// Obsolete
        /// </summary>
        /// <remarks>
        /// Use the BufferingAppenderSkeleton Fix methods instead 
        /// </remarks>
        /// <remarks>
        /// <para>
        /// Obsolete property.
        /// </para>
        /// </remarks>
        [Obsolete("Use the BufferingAppenderSkeleton Fix methods")]
        public bool LocationInfo
        {
            get
            {
                return false;
            }
            set
            {
                ;
            }
        }

        /// <summary>
        /// Gets or sets the SMTP authentication.
        /// </summary>
        /// <value>
        /// The SMTP authentication.
        /// </value>
        public string SmtpAuthentication
        {
            set
            {
                this.smtpAuthentication = value;
            }
            get
            {
                return this.smtpAuthentication;
            }
        }

        /// <summary>
        /// The mode to use to authentication with the SMTP server
        /// </summary>
        /// <remarks>
        /// <note type="caution">Authentication is only available on the MS .NET 1.1 runtime.</note>
        /// <para>
        /// Valid Authentication mode values are: <see cref="SmtpAuthentication.None"/>, 
        /// <see cref="SmtpAuthentication.Basic"/>, and <see cref="SmtpAuthentication.Ntlm"/>. 
        /// The default value is <see cref="SmtpAuthentication.None"/>. When using 
        /// <see cref="SmtpAuthentication.Basic"/> you must specify the <see cref="UserName"/> 
        /// and <see cref="Password"/> to use to authenticate.
        /// When using <see cref="SmtpAuthentication.Ntlm"/> the Windows credentials for the current
        /// thread, if impersonating, or the process will be used to authenticate. 
        /// </para>
        /// </remarks>
        public AuthenticationSmtp SmtpAuth
        {
            get
            {
                AuthenticationSmtp smtpAuth;

                switch (SmtpAuthentication)
                {
                    case "Basic":
                        smtpAuth = AuthenticationSmtp.Basic;
                        break;
                    case "Ntlm":
                        smtpAuth = AuthenticationSmtp.Ntlm;
                        break;
                    default:
                        smtpAuth = AuthenticationSmtp.None;
                        break;
                }

                return smtpAuth;
            }
        }

        /// <summary>
        /// The username to use to authenticate with the SMTP server
        /// </summary>
        /// <remarks>
        /// <note type="caution">Authentication is only available on the MS .NET 1.1 runtime.</note>
        /// <para>
        /// A <see cref="UserName"/> and <see cref="Password"/> must be specified when 
        /// <see cref="Authentication"/> is set to <see cref="SmtpAuthentication.Basic"/>, 
        /// otherwise the username will be ignored. 
        /// </para>
        /// </remarks>
        public string UserName
        {
            get
            {
                return this.userName;
            }
            set
            {
                this.userName = value;
            }
        }

        /// <summary>
        /// The password to use to authenticate with the SMTP server
        /// </summary>
        /// <remarks>
        /// <note type="caution">Authentication is only available on the MS .NET 1.1 runtime.</note>
        /// <para>
        /// A <see cref="UserName"/> and <see cref="Password"/> must be specified when 
        /// <see cref="Authentication"/> is set to <see cref="SmtpAuthentication.Basic"/>, 
        /// otherwise the password will be ignored. 
        /// </para>
        /// </remarks>
        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
            }
        }

        /// <summary>
        /// Gets or sets the priority of the e-mail message
        /// </summary>
        /// <value>
        /// One of the <see cref="MailPriority"/> values.
        /// </value>
        /// <remarks>
        /// <para>
        /// Sets the priority of the e-mails generated by this
        /// appender. The default priority is <see cref="MailPriority.Normal"/>.
        /// </para>
        /// <para>
        /// If you are using this appender to report errors then
        /// you may want to set the priority to <see cref="MailPriority.High"/>.
        /// </para>
        /// </remarks>
        public MailPriority Priority
        {
            get
            {
                return this.mailPriority;
            }
            set
            {
                this.mailPriority = value;
            }
        }


        /// <summary>
        /// Gets or sets the name of the project.
        /// </summary>
        /// <value>The name of the project.</value>
        public string ProjectName
        {
            get
            {
                return this.projectName;
            }
            set
            {
                this.projectName = value;
            }
        }
        #endregion /// Public Instance Properties

        #region Override implementation of AppenderSkeleton
        /// <summary>
        /// Gets a value indicating whether [requires layout].
        /// </summary>
        /// <value><c>true</c> if [requires layout]; otherwise, <c>false</c>.</value>
        protected override bool RequiresLayout
        {
            get
            {
                return false;
            }
        }
        #endregion /// Override implementation of AppenderSkeleton

        #region SendBuffer
        /// <summary>
        /// Sends the contents of the cyclic buffer as an e-mail message.
        /// </summary>
        /// <param name="events">The logging events to send.</param>
        protected override void SendBuffer(LoggingEvent[] events)
        {
            /// Note: this code already owns the monitor for this appender. 
            /// This free us from needing to synchronize again.
            try
            {
                string content = string.Empty;
                StringBuilder contentBuilder = new StringBuilder();

                foreach (LoggingEvent loggingEvent in events)
                {
                    if (this.Evaluator.IsTriggeringEvent(loggingEvent))
                    {
                        SendEmail(loggingEvent, content);
                        content = string.Empty;
                    }
                    else
                    {
                        contentBuilder.Append(GetAppInfoHtmlTable(loggingEvent));
                        contentBuilder.Append(GetWebInfoHtmlTable());
                        contentBuilder.Append("<br /><br />");
                        content = contentBuilder.ToString();
                    }
                }
            }
            catch (Exception e)
            {
                ErrorHandler.Error("Error occurred while sending e-mail notification.", e);
            }
        }
        #endregion

        #region SendEmail
        /// <summary>
        /// Sends the email.
        /// </summary>
        /// <param name="loggingEvent">The logging event.</param>
        /// <param name="attachmentContent">Content of the attachment.</param>
        protected virtual void SendEmail(LoggingEvent loggingEvent, string attachmentContent)
        {
            /// Do not sent email, if isEnableEmailSent is set to False.
            if (!this.IsEmailSentEnable)
            {
                return;
            }

            string html = GetHtmlDocument(loggingEvent);
            string file = string.Empty;

            if (!string.IsNullOrEmpty(attachmentContent))
            {
                file = Path.GetTempFileName();
                File.WriteAllText(file, GetHtmlDocument(attachmentContent));
            }

            try
            {
                if (File.Exists(file))
                    SendEmail(html, file);
                else
                    SendEmail(html);
            }
            catch (Exception ex)
            {
                ErrorHandler.Error("Error occurred while sending Email notification.", ex);
            }

            if (File.Exists(file))
                File.Delete(file);
        }

        /// <summary>
        /// Sends the email.
        /// </summary>
        /// <param name="messageBody">The message body.</param>
        protected virtual void SendEmail(string messageBody)
        {
            this.SendEmail(messageBody, null);
        }

        /// <summary>
        /// Send the email message
        /// </summary>
        /// <param name="messageBody">the body text to include in the mail</param>
        /// <param name="attachmentFile">The attachment file.</param>
        protected virtual void SendEmail(string messageBody, string attachmentFile)
        {
            /// Do not sent email, if isEnableEmailSent is set to False.
            if (!this.IsEmailSentEnable)
            {
                return;
            }

            /// .NET 4.0 has a new API for SMTP email System.Net.Mail
            /// This API supports credentials and multiple hosts correctly.
            /// The old API is deprecated.

            /// Create and configure the smtp client
            SmtpClient smtpClient = new SmtpClient();
            if (this.smtpHost != null && this.smtpHost.Length > 0)
            {
                smtpClient.Host = smtpHost;
            }

            smtpClient.Port = Port;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

            if (this.SmtpAuth == AuthenticationSmtp.Basic)
            {
                // Perform basic authentication
                smtpClient.Credentials = new System.Net.NetworkCredential(this.userName, this.password);
                smtpClient.EnableSsl = IsSslEnable;
            }
            else if (this.SmtpAuth == AuthenticationSmtp.Ntlm)
            {
                // Perform integrated authentication (NTLM)
                smtpClient.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
            }

            MailMessage mailMessage = new MailMessage();
            mailMessage.Body = messageBody;
            mailMessage.From = new MailAddress(this.from);

            //// define which character is seperating fields
            string[] emailTo = this.to.Split(';');
            string cc = string.Empty;
            string to = string.Empty;

            if (emailTo.Length > 1)
            {
                for (int index = 0; index < emailTo.Length; index++)
                {
                    if (index == 0)
                    {
                        to = emailTo[0];
                        mailMessage.To.Add(new MailAddress(to));
                    }
                    else
                    {
                        cc = emailTo[index];
                        mailMessage.CC.Add(new MailAddress(cc));
                    }
                }
            }
            else
            {
                mailMessage.To.Add(new MailAddress(this.to));
            }

            //mailMessage.To.Add(this.to);

            mailMessage.Subject = Subject;
            mailMessage.Priority = this.mailPriority;
            mailMessage.IsBodyHtml = true;

            /// TODO: Consider using SendAsync to send the message without blocking. This would be a change in
            /// behaviour compared to .NET 1.x. We would need a SendCompletedCallback to log errors.
            if (attachmentFile != null && File.Exists(attachmentFile))
            {
                using (System.IO.FileStream fileStream = new System.IO.FileStream(attachmentFile, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    mailMessage.Attachments.Add(new Attachment(fileStream, "Log.html"));
                    smtpClient.Send(mailMessage);
                    fileStream.Close();
                }
            }
            else
            {
                smtpClient.Send(mailMessage);
            }
        }

        #endregion /// Protected Methods

        #region GetHtmlDocument
        /// <summary>
        /// Gets the HTML document.
        /// </summary>
        /// <param name="loggingEvent">The logging event.</param>
        /// <returns>returns the HTML doc</returns>
        private string GetHtmlDocument(LoggingEvent loggingEvent)
        {
            string body = GetAppInfoHtmlTable(loggingEvent);
            body += GetWebInfoHtmlTable();

            return GetHtmlDocument(body);
        }

        /// <summary>
        /// Gets the HTML document.
        /// </summary>
        /// <param name="body">The body.</param>
        /// <returns>returns the HTML doc</returns>
        private string GetHtmlDocument(string body)
        {
            string styles = " body {margin:0px; padding:0px;}";
            string tableClass = ".tableClass {width:100%;}";
            string headingClass = ".headingClass {padding:5px; text-align:right; background-color:#CACAFF; font-weight:bold; font-size:15px;}";
            string leftColClass = ".leftColClass {vertical-align:top; padding:5px; width:125px; background-color:#CACAFF; font-weight:bold; font-size:13px;}";
            string rightColClass = ".rightColClass {vertical-align:top; padding:5px; background-color:#E1E1FF; font-weight:normal; font-size:13px;}";

            string html = "<html>\n<head>\n<title>Error Log</title>\n";
            html += "<style type=\"text/css\">\n";
            html += string.Format("{0}\n{1}\n{2}\n{3}\n{4}\n", tableClass, headingClass, leftColClass, rightColClass, styles);
            html += "</style>\n</head>\n";
            html += string.Format("<body>\n{0}\n</body>\n</html>", body);
            return html;
        }
        #endregion

        #region GetAppInfoHtmlTable
        /// <summary>
        /// Gets the app info HTML table.
        /// </summary>
        /// <param name="loggingEvent">The logging event.</param>
        /// <returns>Returns the HTML Table</returns>
        private string GetAppInfoHtmlTable(LoggingEvent loggingEvent)
        {
            Dictionary<string, string> rows = new Dictionary<string, string>();
            string projectName = string.Empty;
            string subj = string.Empty;
            string user = string.Empty;

            if (HttpContext.Current != null)
            {
                if (HttpContext.Current.User.Identity.Name != null)
                    user = HttpContext.Current.User.Identity.Name;

                projectName = HttpContext.Current.Request.ApplicationPath;
            }
            else
            {
                if (string.IsNullOrEmpty(this.projectName))
                {
                    projectName = System.AppDomain.CurrentDomain.SetupInformation.ApplicationName;

                    if (string.IsNullOrEmpty(projectName))
                    {
                        if (Assembly.GetEntryAssembly() != null)
                        {
                            projectName = Assembly.GetEntryAssembly().FullName;
                        }
                        else if (Assembly.GetCallingAssembly() != null)
                        {
                            projectName = Assembly.GetCallingAssembly().FullName;
                        }
                    }
                }
                else
                {
                    projectName = this.projectName;
                }
            }

            if (string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(loggingEvent.UserName))
                user = loggingEvent.UserName;

            subj = String.Format("[{0}] [{1}] [Project: {2}] [User: {2}]", loggingEvent.Level.DisplayName, Subject, projectName, user);

            this.Subject = subj;
            rows.Add("DateTime", DateTime.Today.ToLongDateString() + " " + DateTime.Now.ToShortTimeString());
            string version = string.Empty;

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                version = String.Format("v{0}.{1}.{2}", ApplicationDeployment.CurrentDeployment.CurrentVersion.Major,
                    ApplicationDeployment.CurrentDeployment.CurrentVersion.Minor,
                    ApplicationDeployment.CurrentDeployment.CurrentVersion.Revision);
            }
            else
            {
                version = String.Format("v{0}", Application.ProductVersion);
            }

            string machineCol1 = "Machine Name<br>Username<br>Application Name<br>Version<br>Memory Usage";
            string machineCol2 = String.Format("<b>{0}</b><br>{1}<br>{2}<br>{3}<br>{4} KB",
                System.Environment.MachineName, user, projectName, version, System.Environment.WorkingSet / 1024);

            rows.Add(machineCol1, machineCol2);
            rows.Add("Message Type", loggingEvent.Level.DisplayName);

            string redStyle = "style=\"color:#CC0000;\"";
            string greenStyle = "style=\"color:Green;\"";

            if (loggingEvent.ExceptionObject != null)
            {
                Exception exception = loggingEvent.ExceptionObject;

                if (!string.IsNullOrEmpty(exception.Source))
                    rows.Add("Source", exception.Source);
                if (!string.IsNullOrEmpty(exception.Message))
                    rows.Add("Message", string.Format("<div {0}><pre>{1}</pre></div>", redStyle, exception.Message));
                if (!string.IsNullOrEmpty(loggingEvent.RenderedMessage))
                    rows.Add("Message Info", string.Format("<div {0}><pre>{1}</pre></div>", greenStyle, loggingEvent.RenderedMessage));
                if (exception.InnerException != null)
                    rows.Add("Inner Exception", exception.InnerException.ToString());
                if (exception.TargetSite != null)
                    rows.Add("Target Site", exception.TargetSite.ToString());

                rows.Add("ToString()", exception.ToString());
            }
            else
            {
                if (loggingEvent.Level >= Level.Error)
                    rows.Add("Message Info", string.Format("<div {0}><pre>{1}<pre></div>", redStyle, loggingEvent.RenderedMessage));
                else
                    rows.Add("Message Info", string.Format("<div {0}><pre>{1}</pre></div>", greenStyle, loggingEvent.RenderedMessage));
            }

            return CreateHtmlTable(rows, "AppInfo");
        }
        #endregion

        #region GetWebInfoHtmlTable

        /// <summary>
        /// Gets the web info HTML table.
        /// </summary>
        /// <returns>Returns Web info HTML table</returns>
        private string GetWebInfoHtmlTable()
        {
            if (System.Web.HttpContext.Current == null)
                return string.Empty;

            Dictionary<string, string> rows = new Dictionary<string, string>();

            if (HttpContext.Current.User.Identity.Name != null)
                rows.Add("User", HttpContext.Current.User.Identity.Name);

            rows.Add("App Path", HttpContext.Current.Request.ApplicationPath);

            if (HttpContext.Current.Request != null)
            {
                StringBuilder colBuilder = new StringBuilder();
                System.Collections.Specialized.NameValueCollection col = HttpContext.Current.Request.Params;

                foreach (string key in col.Keys)
                {
                    colBuilder.AppendFormat("{0} = {1}<br/>\n", key, col[key]);
                }

                rows.Add("Request Details", colBuilder.ToString());
            }

            return CreateHtmlTable(rows, "WebInfo");
        }
        #endregion

        #region CreateHtmlTable
        /// <summary>
        /// Creates the HTML table.
        /// </summary>
        /// <param name="rows">The rows.</param>
        /// <param name="heading">The heading.</param>
        /// <returns>returns HTML table</returns>
        private string CreateHtmlTable(Dictionary<string, string> rows, string heading)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string key in rows.Keys)
            {
                sb.AppendFormat("<tr><td class=\"leftColClass\">{0}</td><td class=\"rightColClass\">{1}</td></tr>\n", key, rows[key]);
            }

            string headingRow = string.Format("<tr><td class=\"leftColClass\" style=\"color:#CACAFF;\">_________________<td class=\"headingClass\">{0}</td></tr>\n", heading);
            string table = String.Format("\n<table class=\"tableClass\" cellpadding=\"0\" cellspacing=\"2\">\n{0}\n{1}</table>\n", headingRow, sb.ToString());

            return table;
        }
        #endregion


    }


    


    */

}
