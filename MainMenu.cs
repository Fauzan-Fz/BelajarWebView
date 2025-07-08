using System;
using System.ComponentModel;
using System.Data.SQLite;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using PuppeteerWebView.Models;
using WebView2.DevTools.Dom;
using File = System.IO.File;

namespace PuppeteerWebView
{
    /// Form utama aplikasi yang mengelola interaksi WebView2 dan DevTools
    /// untuk mengotomasi navigasi dan manipulasi website.
    public partial class PuppeteerForm : Form
    {
        #region Variable

        /*
         * Region Variable:
         * Menyimpan variabel-variabel utama yang digunakan untuk konfigurasi,
         * status aplikasi, dan objek DevTools context.
         */
        private string website = "https://www.indonetwork.co.id/";
        private string tools = "indonetwork.co.id";
        private int targetSet = 0;
        private bool isStopped = false;
        private bool isDebug = false;
        private int NoLogs = 0;

        private WebView2DevToolsContext Page;

        public DataSettings DS = new DataSettings();

        #endregion Variable

        public PuppeteerForm()
        {
            InitializeComponent();
        }

        #region Event_Website

        /*
         * Region Event_Website:
         * Berisi metode-metode yang berkaitan dengan inisialisasi dan pengelolaan
         * WebView2, termasuk event handler untuk permintaan resource web.
         */

        /// Memastikan WebView2 sudah siap digunakan.
        private async Task startAdd()
        {
            await webView21.EnsureCoreWebView2Async(null);
        }

        /// Memulai browser, menginisialisasi DevTools context, dan mengatur event handler.
        public async void startBrowser()
        {
            await startAdd();
            Page = await webView21.CoreWebView2.CreateDevToolsContextAsync();

            webView21.CoreWebView2.WebResourceRequested += CoreWebView2_WebResourceRequested;
            webView21.CoreWebView2.AddWebResourceRequestedFilter(null, CoreWebView2WebResourceContext.Image);
            webView21.CoreWebView2.Navigate($"{website}");
        }

        /// Event handler untuk memblokir permintaan resource gambar.
        private void CoreWebView2_WebResourceRequested(object sender, CoreWebView2WebResourceRequestedEventArgs e)
        {
            e.Response = webView21.CoreWebView2.Environment.CreateWebResourceResponse(null, 404, "Not found", null);
        }

        #endregion Event_Website

        #region Fungsi

        /*
         * Region Fungsi:
         * Berisi fungsi utilitas untuk mendapatkan URL kategori berdasarkan input.
         */

        /// Mengembalikan URL kategori berdasarkan nama kategori yang dipilih.
        public string kategoriGet(string value)
        {
            string hasil = "";
            switch (value)
            {
                case "Mesin Peralatan Industri":
                    hasil = "https://www.indonetwork.co.id/k/mesin-peralatan-industri";
                    break;

                case "Perlengkapan Listrik dan Elektronik":
                    hasil = "https://www.indonetwork.co.id/k/perlengkapan-listrik-elektronik";
                    break;

                case "Furnitur & Peralatan Rumah Tangga":
                    hasil = "https://www.indonetwork.co.id/k/furnitur";
                    break;

                case "Bahan Bangunan":
                    hasil = "https://www.indonetwork.co.id/k/bahan-bangunan";
                    break;

                case "Komputer & Laptop":
                    hasil = "https://www.indonetwork.co.id/k/komputer-dan-laptop";
                    break;

                case "Pakaian & Aksesoris":
                    hasil = "https://www.indonetwork.co.id/k/fashion-tekstil-dan-aksesoris";
                    break;

                case "Otomotif & Transportasi":
                    hasil = "https://www.indonetwork.co.id/k/otomotif-dan-transportasi";
                    break;

                case "Agrobisnis & Produk Pangan":
                    hasil = "https://www.indonetwork.co.id/k/agrobisnis-produk-pangan";
                    break;

                case "Kerajinan & Souvenir":
                    hasil = "https://www.indonetwork.co.id/k/kerajinan-dan-souvenir\r\n";
                    break;

                case "Bahan Kimia":
                    hasil = "https://www.indonetwork.co.id/k/metalurgi-mineral-dan-kimia";
                    break;
            }
            return hasil;
        }

        // Menambahkan log aktivitas scraping ke UI.
        public void AddLogs(string status, string text)
        {
            NoLogs += 1;
            logs_text.Text = text;
            DateTime localTime = DateTime.Now;
            string time = localTime.ToString("MM/dd/yyyy HH:mm:ss");
            dgvLogs.Rows.Add(NoLogs, time, status, text);
            dgvLogs.Sort(dgvLogs.Columns["id_logs"], ListSortDirection.Descending);
        }

        // Menambahkan hasil scraping ke tabel dan database SQLite.
        public void AddResult(Data DT)
        {
            int Step = 0;
            try
            {
                Step = 1;
                dgvResult.Rows.Add(DT.Name, DT.Phone, DT.Email, DT.Website, DT.Rating, DT.Reviews, DT.Address);

                Step = 2;
                var myConnection = new SQLiteConnection("Data Source=scrapeTool.sqlite3");
                void OpenConnection() // Buka Koneksi
                {
                    if (myConnection.State != System.Data.ConnectionState.Open)
                    {
                        myConnection.Open();
                    }
                }

                Step = 3; // Tutup Koneksi
                void CloseConnection()
                {
                    if (myConnection.State != System.Data.ConnectionState.Closed)
                    {
                        myConnection.Close();
                    }
                }

                Step = 4; // Membuat File Database
                if (!File.Exists("./scrapeTool.sqlite3"))
                {
                    SQLiteConnection.CreateFile("scrapeTool.sqlite3");
                    string creat_tabel = "CREATE TABLE 'lead' ( 'Id' integer NOT NULL, 'Unik' text(100), 'ExtId' text(50) NOT NULL, 'Name' text(150) NOT NULL, 'Category' text(100), 'Photo' text(250), 'Address' text(250), 'LocatedIn' text(250), 'Phone' text(250), 'Website' text(100), 'Rating' text(10), 'Reviews' text(10), 'Postal' text(10), 'Latitude' text(30), 'Longitude' text(30), 'OpenHours' text, 'Location' text(150), 'Email' text(250), 'Phone2' text(100), 'ExtSites' text, 'Url' text(350), 'Tool' text(28), 'Search' text(250), 'ListId' text(250), 'Progress' integer(11), 'In' text, 'Up' text, 'Country' TEXT, 'City' TEXT, 'State' TEXT, 'Tags' TEXT, PRIMARY KEY ('Id'))";
                    SQLiteCommand buat_tabel = new SQLiteCommand(creat_tabel, myConnection);
                    OpenConnection();
                    buat_tabel.ExecuteNonQuery();
                    CloseConnection();
                }

                Step = 5; // Insert ke Database
                string query = "INSERT INTO lead (Unik, ExtId, Name, Category, Photo, Address, LocatedIn, Phone, Website, Rating, Reviews, Postal, Latitude, Longitude, OpenHours, Location, Email, Phone2, ExtSites, Url, Tool, Search,Country,City,State) VALUES (@Unik, @ExtId, @Name, @Category, @Photo, @Address, @LocatedIn, @Phone, @Website, @Rating, @Reviews, @Postal, @Latitude, @Longitude, @OpenHours, @Location, @Email, @Phone2, @ExtSites, @Url, @Tool, @Search, @Country, @City, @State)";
                SQLiteCommand myCommand = new SQLiteCommand(query, myConnection);
                OpenConnection();

                Step = 6; // Insert ke Database
                myCommand.Parameters.AddWithValue("@Unik", $"{tools}-{DT.ExtId}");
                myCommand.Parameters.AddWithValue("@ExtId", $"{DT.ExtId}");
                myCommand.Parameters.AddWithValue("@Name", $"{DT.Name}");
                myCommand.Parameters.AddWithValue("@Category", $"{comboBox_Kategori.Text}");
                myCommand.Parameters.AddWithValue("@Photo", $"{DT.Photo}");
                myCommand.Parameters.AddWithValue("@Address", $"{DT.Address}");
                myCommand.Parameters.AddWithValue("@LocatedIn", $"{DT.LocatedIn}");
                myCommand.Parameters.AddWithValue("@Phone", $"{DT.Phone}");
                myCommand.Parameters.AddWithValue("@Website", $"{DT.Website}");
                myCommand.Parameters.AddWithValue("@Rating", $"{DT.Rating}");
                myCommand.Parameters.AddWithValue("@Reviews", $"{DT.Reviews}");
                myCommand.Parameters.AddWithValue("@Postal", $"{DT.Postal}");
                myCommand.Parameters.AddWithValue("@Latitude", $"{DT.Latitude}");
                myCommand.Parameters.AddWithValue("@Longitude", $"{DT.Longitude}");
                myCommand.Parameters.AddWithValue("@OpenHours", $"{DT.OpenHours}");
                myCommand.Parameters.AddWithValue("@Location", $"{DT.Location}");
                myCommand.Parameters.AddWithValue("@Email", $"{DT.Email}");
                myCommand.Parameters.AddWithValue("@Phone2", $"{DT.Phone2}");
                myCommand.Parameters.AddWithValue("@ExtSites", $"{DT.ExtSites}");
                myCommand.Parameters.AddWithValue("@Url", $"{DT.Url}");
                myCommand.Parameters.AddWithValue("@Tool", $"{tools}");
                myCommand.Parameters.AddWithValue("@Search", $"{DT.Search}");
                myCommand.Parameters.AddWithValue("@Country", $"{DT.Country}");
                myCommand.Parameters.AddWithValue("@City", $"{DT.City}");
                myCommand.Parameters.AddWithValue("@State", $"{DT.State}");

                Step = 7;
                var result = myCommand.ExecuteNonQuery();
                CloseConnection();
            }
            catch (Exception ex)
            {
                AddLogs("Error", "Not Add Result");
            }
        }

        #endregion Fungsi

        /// Event handler untuk memulai browser saat form dimuat.
        private void LoadForm(object sender, System.EventArgs e)
        {
            startBrowser();
            AddLogs("Load Website", $"Ready to scrape : {website}");
            DS.GetList_Start = 3;
            DS.GetList_End = 5;
            DS.GetDetail_Start = 3;
            DS.GetDetail_End = 5;
            DS.NextPage_Start = 3;
            DS.NextPage_End = 5;
        }

        // Event handler untuk menavigasi ke kategori yang dipilih.
        private void Select_Kategori(object sender, EventArgs e)
        {
            webView21.CoreWebView2.Navigate($"{kategoriGet(comboBox_Kategori.Text)}");
        }

        // Mengatur apakah gambar dimuat atau diblokir saat scraping.
        private void Image_Load(object sender, System.EventArgs e)
        {
            webView21.CoreWebView2.CallDevToolsProtocolMethodAsync("Network.clearBrowserCache", "{}");
            if (this.checkBox_DisableImage.CheckState == CheckState.Unchecked)
            {
                webView21.CoreWebView2.WebResourceRequested += CoreWebView2_WebResourceRequested;
                webView21.CoreWebView2.AddWebResourceRequestedFilter(null, Microsoft.Web.WebView2.Core.CoreWebView2WebResourceContext.Image);
                webView21.CoreWebView2.Reload();
            }
            else
            {
                webView21.CoreWebView2.WebResourceRequested -= CoreWebView2_WebResourceRequested;
                webView21.CoreWebView2.Reload();
            }
        }

        // Event untuk mengatur jumlah data target scraping.
        private void Jumlah_Data(object sender, System.EventArgs e)
        {
            targetSet = (int)num_JumlahData.Value;
        }

        // Menentukan mode debug aktif atau tidak berdasarkan checkbox.
        private void Debug_Check(object sender, System.EventArgs e)
        {
            if (this.checkBox_DisableImage.CheckState == CheckState.Checked)
            {
                isDebug = true;
            }
            else
            {
                isDebug = false;
            }
        }

        // Menampilkan form pengaturan scraping.
        private void Open_Setting(object sender, EventArgs e)
        {
            var settingForm = new Settings();
            settingForm.Account(DS.Username, DS.Password);
            settingForm.GetList(DS.GetDetail_Start, DS.GetList_End);
            settingForm.GetDetail(DS.GetDetail_Start, DS.GetDetail_End);
            settingForm.NextPage(DS.NextPage_Start, DS.NextPage_End);
            settingForm.ShowDialog();
        }
    }
}