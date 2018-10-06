using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
    public sealed partial class AddToFavorite : Page
    {
        public AddToFavorite()
        {
            this.InitializeComponent();
        }
        private void btBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Page_QAView));
        }


        private async void btLuu_ClickAsync(object sender, RoutedEventArgs e)
        {
           // CreateQAList.listQAFavorite.Clear();
            string success = "";
            foreach (QuestionAndAnswer QA in CreateQAList.listQA)
            {
                if (QA.thu_tu == Convert.ToInt32(txtThuTu.Text))
                {
                    QA.yeu_thich = true;
                    //CreateQAList.listQAFavorite.Add(QA);

                    string text = JsonConvert.SerializeObject(CreateQAList.listQA);

                    //File.WriteAllText(Path.Combine(path), text);
                    await WriteFile(text);
                    
                    success = "Đã thêm vào thành công";
                    
                }

            }

            if (success == "")
            {
                MessageDialog thongbao1 = new MessageDialog("Không tìm thấy câu cần lưu!");
                await thongbao1.ShowAsync();

            }
            else
            {
                MessageDialog thongbao1 = new MessageDialog(success);
                await thongbao1.ShowAsync();
            }

        }

        private async Task WriteFile(string text)
        {

            StorageFolder folder = ApplicationData.Current.LocalFolder;
            StorageFile file = await folder.GetFileAsync("QA.json");
            await FileIO.WriteTextAsync(file, text);

        }
    }
}
