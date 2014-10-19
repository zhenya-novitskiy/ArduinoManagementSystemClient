using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using ArduinoManagementSystem.Components.ColorChanger.Control.ColorChangerComponents;
//using Microsoft.Office.Interop.Outlook;
using Action = System.Action;

namespace ArduinoManagementSystem.Components.Email
{
    /// <summary>
    /// Interaction logic for EmailControl.xaml
    /// </summary>
    public partial class EmailControl : UserControl
    {

        //private Microsoft.Office.Interop.Outlook.Application OutApplication = new Microsoft.Office.Interop.Outlook.Application();
        //private NameSpace oNS;
        //private Items items;
        public EmailControl()
        {
            InitializeComponent();
            DataContext = this;
            //OutApplication.NewMail += ItemsItemChange;

 //           oNS = OutApplication.GetNamespace("mapi");
   //         oNS.Logon(Missing.Value, Missing.Value, true, true);
     //       items = oNS.GetDefaultFolder(OlDefaultFolders.olFolderInbox).Items;
       //     items.ItemChange += ItemsItemChange;
            UpdateEmailStatus();

        }

        void ItemsItemChange()
        {
            UpdateEmailStatus();
        }
        void ItemsItemChange(object Item)
        {
            UpdateEmailStatus();
        }


        public Visibility HasUnreadedEmail
        {
            get { return (Visibility)GetValue(HasUnreadedEmailProperty); }
            set { SetValue(HasUnreadedEmailProperty, value); }
        }


        public static readonly DependencyProperty HasUnreadedEmailProperty = DependencyProperty.Register(
            "HasUnreadedEmail",
            typeof(Visibility),
            typeof(EmailControl),
            new PropertyMetadata(Visibility.Collapsed, null)
        );

        private void UpdateEmailStatus ()
        {
            DispatcherOperation update = this.Dispatcher.BeginInvoke(new Action(() =>
            {
                SetValue(HasUnreadedEmailProperty, (MailsHasUnreaded() ? Visibility.Visible : Visibility.Collapsed));
            }), DispatcherPriority.Send);
        }

        private bool MailsHasUnreaded()
        {
         //   MAPIFolder inbox = oNS.GetDefaultFolder(OlDefaultFolders.olFolderInbox);

//            var result = inbox.Items.Find("[UnRead] = True ");
  //          return result is MailItem;
            return false;
        }

        public BitmapImage TakeScreenShot()
        {
            return ScreenshotCreator.TakeImageFrom(this);
        }

        public void SwapToOverlayCopy(BitmapImage controlImage)
        {
            throw new NotImplementedException();
        }
    }
}
