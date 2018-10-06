using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;
using Windows.ApplicationModel;
using Windows.Data.Json;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using Newtonsoft.Json;
using Windows.UI.Popups;

namespace LaborLawHandBook
{
    class CreateQAList
    {
        public static List<QuestionAndAnswer> listQA = new List<QuestionAndAnswer>();
        public static List<QuestionAndAnswer> listQAFavorite = new List<QuestionAndAnswer>();
        public static List<QuestionAndAnswer> listResult = new List<QuestionAndAnswer>();
       
        public static async Task<List<QuestionAndAnswer>> createQAListAsync()
        {
          
            var assembly = typeof(CreateQAList).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("LaborLawHandBook.Resources.QA.json");
            using (var reader = new StreamReader(stream ?? throw new InvalidOperationException()))
            {
                var json = reader.ReadToEnd();
                StorageFolder folder = ApplicationData.Current.LocalFolder;

                var file = await folder.TryGetItemAsync("QA.json");
                if (file == null)
                {
                    StorageFile fileStorage = await folder.CreateFileAsync("QA.json",
                    CreationCollisionOption.ReplaceExisting);

                    await FileIO.WriteTextAsync(fileStorage, json);
                } else
                {
                    StorageFile fileStorage = await folder.GetFileAsync("QA.json");
                    json = await FileIO.ReadTextAsync(fileStorage);
                }
                
                listQA = JsonConvert.DeserializeObject<List<QuestionAndAnswer>>(json);
            }

            return listQA;
        }

        public static List<QuestionAndAnswer> CreateQAFavorite() {
            foreach (QuestionAndAnswer QA in listQA)
            {
                if (QA.yeu_thich == true)
                {
                    listQAFavorite.Add(QA);
                }
            }

            return listQAFavorite;
        }

    }
}
