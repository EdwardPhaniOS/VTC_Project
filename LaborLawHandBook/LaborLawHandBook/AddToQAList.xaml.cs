using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LaborLawHandBook
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddToQAList : Page
    {
        public AddToQAList()
        {
            this.InitializeComponent();
        }
        private void btBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Page_QAView));
        }
   
        private async void btLuu_ClickAsync(object sender, RoutedEventArgs e)
        {
            string ERR = "";

            foreach (QuestionAndAnswer item in CreateQAList.listQA)
            {
                if (item.cau_hoi == txtCauHoi.Text)
                {
                    ERR = "Câu hỏi bị trùng, vui lòng nhập câu hỏi khác";
                }

            }

            if (txtCauHoi.Text == "")
            {
                ERR += "Vui lòng nhập câu hỏi\n";
            }

            if (txtDapAn.Text == "")
            {
                ERR += "Vui lòng nhập đáp án\n";
            }

            if (ERR != "")
            {
                MessageDialog thongbao = new MessageDialog("Lỗi:\n" + ERR);
                await thongbao.ShowAsync();
                return;
            }
            QuestionAndAnswer QA = new QuestionAndAnswer();
            int thu_tu = CreateQAList.listQA.Count() + 1;
            QA.thu_tu = thu_tu;
            QA.cau_hoi = "Câu số " + thu_tu + ": " + txtCauHoi.Text;
            QA.dap_an = "\n" + txtDapAn.Text;

            CreateQAList.listQA.Add(QA);
            
            //TODO: save CreateQAList.listAdded to file

            //string path = @"C:\Users\Vinh";
            string text = JsonConvert.SerializeObject(CreateQAList.listQA);

            //File.WriteAllText(Path.Combine(path), text);
            await WriteFile(text);
            

            MessageDialog thongbao1 = new MessageDialog("Đã lưu thành công!");
            await thongbao1.ShowAsync();


        }

        private async Task WriteFile(string text)
        {

            StorageFolder folder = ApplicationData.Current.LocalFolder;
            StorageFile file = await folder.GetFileAsync("QA.json");
            await FileIO.WriteTextAsync(file, text);

        }
    }
}
