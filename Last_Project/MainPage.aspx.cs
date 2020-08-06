using Microsoft.Office.Interop.Word;
using System;
using System.IO;
using System.Text;
using Microsoft.Office;
using System.Collections.Generic;

namespace Last_Project
{
    public partial class MainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "Исключения: ";
        }

        protected void SaveBut_Click(object sender, EventArgs e)//сохранение в файл
        {
            if (TxtBut.Checked == true)
            {
                try
                {
                    string path = Server.MapPath("Files//" + "newFile.txt");
                    File.WriteAllText(path, TextBox2.Text, Encoding.GetEncoding(1251));
                    Label1.Text = "Файл сохранен в папке Files";
                }
                catch(Exception ex)
                {
                    Label1.Text = ex.Message;
                }
            }
            else if (DocxBut.Checked == true)
            {
                Application application = null;
                try
                {
                    application = new Application();
                    var document = application.Documents.Add();
                    var paragraph = document.Paragraphs.Add();
                    paragraph.Range.Text = TextBox2.Text;

                    string filename = Server.MapPath("Files//" + "newFile.docx");
                    application.ActiveDocument.SaveAs(filename, WdSaveFormat.wdFormatDocumentDefault);
                    document.Close();
                    application.Quit();
                    Label1.Text = "Файл сохранен в папке Files";
                }
                catch (Exception ex)
                {
                    Label1.Text = ex.Message;
                }
            }
            else
            {
                Label1.Text = "Выберите .txt или .docx!";
            }
        }

        protected void CountBut_Click(object sender, EventArgs e)//РАСШИФРОВАТЬ И ЗАШИФРОВАТЬ
        {
            VigCipher cipher = new VigCipher("АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ");
            if (DecryptBut.Checked == true)
            {
                string decryptedText = cipher.Decrypt(TextBox1.Text, TextBox3.Text);
                TextBox2.Text = decryptedText;
            }
            else if (EncryptBut.Checked == true)
            {
                string encryptedText = cipher.Encrypt(TextBox1.Text, TextBox3.Text);
                TextBox2.Text = encryptedText;
            }
            else
            {
                Label1.Text = "Выберите Расшифровать или Зашифровать";
            }
        }

        protected void OpenButton_Click(object sender, EventArgs e)//ОТКРЫТЬ ФАЙЛ
        {
            
            try
            {
                string folder = Server.MapPath("Files\\");
                string path = folder + btn_upload.FileName;
                btn_upload.SaveAs(path);
                FileInfo file = new FileInfo(path);
                string extension = file.Extension;
                OpenFileFromString(path, extension);
            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
            }
        }

        private void OpenFileFromString(string path, string extension)
        {
            Application word = new Application();
            Document doc = new Document();
            if (btn_upload.HasFile)
            {
                object fileName = path;
                // Define an object to pass to the API for missing parameters
                object missing = Type.Missing;
                object visible = true;

                if (extension == ".docx" || extension == ".doc")
                {
                    doc = word.Documents.Open(ref fileName,
                            ref missing, ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref visible, ref missing,
                            ref missing, ref missing, ref missing);
                    TextBox1.Text = doc.Content.Text;
                }
                else if (extension == ".txt")
                {
                    doc = word.Documents.Open(ref fileName,
                            ref missing, ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing, ref missing,
                            ref missing, 1251, ref visible, ref missing,
                            ref missing, ref missing, ref missing);
                    TextBox1.Text = doc.Content.Text;
                }
                else
                {
                    Label1.Text = "Выберите формат .txt или .docx";
                }
                doc.Close();
                word.Quit();
            }
        }

    }
   
}