﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using Newtonsoft.Json;
using WebView2.DevTools.Dom;
using WebView2.DevTools.Dom.Input;
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
        private bool loginTrue = false;

        private WebView2DevToolsContext Page;

        public string Username { get; set; }
        public string Password { get; set; }
        public int GetList_Start { get; set; }
        public int GetList_End { get; set; }
        public int GetDetail_Start { get; set; }
        public int GetDetail_End { get; set; }
        public int NextPage_Start { get; set; }
        public int NextPage_End { get; set; }

        private List<Data> dataList;
        private List<Data> dataDetail;

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

        #region Event Form

        /// Event handler untuk memulai browser saat form dimuat.
        private void LoadForm(object sender, System.EventArgs e)
        {
            startBrowser();
            AddLogs("Load Website", $"Ready to scrape : {website}");

            GetList_Start = 3;
            GetList_End = 5;
            GetDetail_Start = 3;
            GetDetail_End = 5;
            NextPage_Start = 3;
            NextPage_End = 5;

            targetSet = (int)num_JumlahData.Value;
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
            if (this.checkBox_Debug.CheckState == CheckState.Checked)
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
            settingForm.Account(Username, Password);
            settingForm.GetList(GetDetail_Start, GetList_End);
            settingForm.GetDetail(GetDetail_Start, GetDetail_End);
            settingForm.NextPage(NextPage_Start, NextPage_End);
            settingForm.ShowDialog();
        }

        private async void StartScrape(object sender, EventArgs e)
        {
            int Step = 0;
            try
            {
                Step = 1; // Tambahkan Variabel
                dataList = new List<Data>();
                dataDetail = new List<Data>();

                Step = 2; // Kondisi Target Kosong
                if (targetSet == 0)
                {
                    MessageBox.Show("Tolong Isi Target Data Terlebih Dahulu", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Step = 3; // Kondisi Target Kosong
                if (string.IsNullOrEmpty(comboBox_Kategori.Text))
                {
                    MessageBox.Show("Tolong Isi Kategori Terlebih Dahulu", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Step = 4; // Auto Login
                await AutoLogin();
                if (loginTrue == false)
                {
                    return;
                }

                Step = 5;
                await GetList();

                Step = 6; // Kondisi List Kosong
                if (dataList.Count() == 0)
                {
                    MessageBox.Show($"List Kosong / Tidak Ditemukan", "Stop Scrape", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    AddLogs("Error", "List Kosong / Tidak Ditemukan");
                    return;
                }

                Step = 7; // Mulai Scrape
                foreach (var item in dataList)
                {
                    await GetDetail(item);
                }

                Step = 8;
                AddLogs("Start Scrape", $"Berhasil Scrape : {website}");
                MessageBox.Show($"Berhasil Scrape : {website}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                AddLogs("Error", $"Start Scrape : {Step}, {ex}");
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (isStopped == false)
            {
                isStopped = true;
            }
            else
            {
                isStopped = false;
            }
        }

        #endregion Event Form

        #region Logic Scrape

        public async Task GetList()
        {
            int Step = 0;
            int pageNext = 1;
            try
            {
            paging:
                // Tunggu Sebelum Scrape
                var Tunggu = new RandomGenerator().RandomNumber(GetList_Start, GetList_End);
                await Task.Delay(Tunggu * 1000);

                Step = 1; // Kondisi Target Kosong
                var container = await Page.WaitForXPathAsync("//div[contains(@class, 'main-list')]", new WaitForSelectorOptions { Visible = true });
                if (container == null)
                {
                    AddLogs("Error", "Tidak Ditemukan List Data Saat Ini");
                    return;
                }

                Step = 3; // List Item Product
                var itemList = await container.XPathAsync(".//div[contains(@class, 'title')]");
                if (itemList == null)
                {
                    AddLogs("Error", "Tidak Ditemukan List Data Saat Ini");
                    return;
                }

                Step = 4; // Mengambil Data
                foreach (var item in itemList)
                {
                    if (isStopped)
                    {
                        AddLogs("Error", $"Stop Scrape : {website}");
                        return;
                    }

                    if (dataList.Count < targetSet)
                    {
                        Step = 5; // Nama Produk
                        var DT = new Data();
                        await item.EvaluateFunctionAsync("e => e.scrollIntoView()");

                        Step = 6;  // Nama Produk
                        var name = await item.XPathAsync("./a");
                        if (name.Length > 0)
                        {
                            DT.Url = await name[0].EvaluateFunctionAsync<string>("e => e.href", name[0]);
                            DT.Name = await name[0].EvaluateFunctionAsync<string>("e => e.innerText", name[0]);
                        }

                        Step = 7; // Kondisi Url Kosong
                        if (!string.IsNullOrEmpty(DT.Url))
                        {
                            Step = 8; // Menampilkan Data
                            dataList.Add(DT);

                            if (isDebug)
                            {
                                AddLogs("Data List", $"{dataList.Count()}. {DT.Name} - {DT.Url}");
                            }
                        }
                    }
                }

                AddLogs("Output", $"Page {pageNext.ToString()} - {itemList.Length} Element - Queue {dataList.Count()} Data");

                Step = 9;
                if (dataList.Count < targetSet)
                {
                    Step = 10; // Navigasi Halaman
                    var btnNext = await Page.XPathAsync("//ul[contains(@class, 'paging')]//span");
                    if (btnNext.Length > 0)
                    {
                        string numBer = await btnNext[0].EvaluateFunctionAsync<string>("e => e.textContent", btnNext[0]);

                        int Next = int.Parse(numBer) + 1;

                        var btnClick = await Page.XPathAsync($"//ul[contains(@class, 'paging')]//a[text()='{Next}']");
                        if (btnClick.Length > 0)
                        {
                            var Tunggu2 = new RandomGenerator().RandomNumber(NextPage_Start, NextPage_End);
                            await Task.Delay(Tunggu2 * 1000);

                            await btnClick[0].EvaluateFunctionAsync("e => e.scrollIntoView()");
                            await btnClick[0].EvaluateFunctionAsync("e => e.click()");
                            pageNext += 1;
                            goto paging;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                AddLogs("Error", $"Start Scrape : {Step}, {ex}");
            }
        }

        public async Task GetDetail(Data Dtl)
        {
            int Step = 0;
            try
            {
                if (isStopped)
                {
                    AddLogs("Error", $"Stop Scrape : {website}");
                    return;
                }

                Step = 1; //Data
                var DT = new Data();

                Step = 2; // Page goto Produk
                webView21.CoreWebView2.Navigate(Dtl.Url);

                var Tunggu = new RandomGenerator().RandomNumber(GetDetail_Start, GetDetail_End);
                await Task.Delay(Tunggu * 1000);

                Step = 3; // Wait
                var boxComapany = await Page.WaitForXPathAsync("//div[contains(@class,'company-box')]", new WaitForSelectorOptions { Visible = true });
                if (boxComapany == null)
                {
                    AddLogs("Error", "Company Box Tidak Ditemukan Saat Ini");
                    return;
                }

                Step = 4; // Ambil Data Company
                var namaC = await boxComapany.XPathAsync(".//h3/a");
                if (namaC.Length > 0)
                {
                    DT.Name = await namaC[0].EvaluateFunctionAsync<string>("e => e.textContent", namaC[0]);
                    string ExtId = await namaC[0].EvaluateFunctionAsync<string>("e => e.href", namaC[0]);
                    DT.ExtId = ExtId.Split('/').Last();
                }

                Step = 5; // Ambil Gambar atau Logo
                var picture = await boxComapany.XPathAsync(".//img");
                if (picture.Length > 0)
                {
                    DT.Photo = await picture[0].EvaluateFunctionAsync<string>("e => e.src", picture[0]);
                }

                Step = 6; // Ambil Alamat
                var address = await boxComapany.XPathAsync(".//div[contains(text(),'Indonesia')]");
                if (address.Length > 0)
                {
                    DT.Address = await address[0].EvaluateFunctionAsync<string>("e => e.innerText", address[0]);
                    if (!string.IsNullOrEmpty(DT.Address))
                    {
                        DT.Postal = DT.Address.Split('-').Last();
                        string[] Lokasi = DT.Address.Split(',');
                        if (Lokasi.Length > 0)
                        {
                            DT.Country = Lokasi[Lokasi.Length - 1].GetBefore("-");
                            DT.State = Lokasi[Lokasi.Length - 2];
                            DT.City = Lokasi[Lokasi.Length - 3].Split("-").Last();
                        }
                    }
                }

                Step = 7; // Ambil No-Telp

                // Mengambil dari Text

                var phoneNum = await boxComapany.XPathAsync(".//button[@data-type='phone']");
                //if (phoneNum.Length > 0)
                //{
                //    await phoneNum[0].EvaluateFunctionAsync("e => e.scrollIntoView()");
                //    await phoneNum[0].EvaluateFunctionAsync("e => e.click()");

                //    var resultPhone = await Page.WaitForXPathAsync("//div[][contains(@class,'conatact-detail')]", new WaitForSelectorOptions { Visible = true });
                //    if (resultPhone != null)
                //    {
                //        var Phone1 = await resultPhone.XPathAsync("./a[1]/span");
                //        if (Phone1.Length > 0)
                //        {
                //            DT.Phone = await Phone1[0].EvaluateFunctionAsync<string>("e => e.textContent", Phone1[0]);
                //        }

                //        var Phone2 = await resultPhone.XPathAsync("./a[2]/span");
                //        if (Phone2.Length > 0)
                //        {
                //            DT.Phone2 = await Phone2[0].EvaluateFunctionAsync<string>("e => e.textContent", Phone2[0]);
                //        }

                //        if (!string.IsNullOrEmpty(DT.Phone2) && DT.Phone2 == DT.Phone)
                //        {
                //            DT.Phone2 = null;
                //        }
                //    }
                //}

                /* - */

                // Mengambil dari No-Phone Payload
                var payload = new Payload();
                payload.Url = "leads/ajax";
                payload.Id = await phoneNum[0].EvaluateFunctionAsync<string>("e => e.dataset.id", phoneNum[0]);
                payload.Text = await phoneNum[0].EvaluateFunctionAsync<string>("e => e.dataset.text", phoneNum[0]);
                payload.Type = await phoneNum[0].EvaluateFunctionAsync<string>("e => e.dataset.type", phoneNum[0]);

                var json = JsonConvert.SerializeObject(payload);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var url = "https://www.indonetwork.co.id/ajax";
                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/138.0.0.0 Safari/537.36");

                HttpResponseMessage response = await client.PostAsync(url, data);
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadAsStringAsync();
                var phoneResult = JsonConvert.DeserializeObject<Respond>(result);

                if (!string.IsNullOrEmpty(phoneResult.text))
                {
                    DT.Phone = phoneResult.text;

                    string[] PhoneFilter = DT.Phone.Split('/');
                    if (PhoneFilter.Length > 0)
                    {
                        DT.Phone = PhoneFilter[0];
                        DT.Phone2 = PhoneFilter[1];
                    }
                }

                /* - */

                Step = 8; // Mengarahkan ke pemasang
                await namaC[0].EvaluateFunctionAsync("e => e.click()");

                Step = 9; // Ambil Website Pemasang
                var CompanyInfo = await Page.WaitForXPathAsync("//div[contains(@class,'company-info')]", new WaitForSelectorOptions { Visible = true });
                if (CompanyInfo != null)
                {
                    var website = await CompanyInfo.XPathAsync(".//a[contains(@class,'btn-domain')]");
                    if (website.Length > 0)
                    {
                        DT.Website = await website[0].EvaluateFunctionAsync<string>("e => e.href", website[0]);
                    }
                }

                if (isStopped)
                {
                    AddLogs("Error", $"Stop Scrape : {website}");
                    return;
                }

                Step = 10; // Check Kondisi ExtId
                if (!string.IsNullOrEmpty(DT.ExtId))
                {
                    Step = 11; // Kondisi Filter Data Sama
                    var dataSama = dataDetail.Where(c => c.ExtId == DT.ExtId).Count();

                    if (dataSama <= 0)
                    {
                        Step = 12;
                        AddResult(DT);

                        if (isDebug)
                        {
                            AddLogs("Result", DT.SerializeJson());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                AddLogs("Error", $"Get Detail {Step} {ex}");
            }
        }

        public async Task AutoLogin()
        {
            int Step = 0;
            try
            {
                Step = 1; // Cek Username dan Password
                if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
                {
                    AddLogs("Stop Scrape", "Tolong Isi Username dan Password Terlebih Dahulu");
                    isStopped = true;
                    MessageBox.Show("Tolong Isi Username dan Password Terlebih Dahulu", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var navBar = await Page.WaitForXPathAsync("//header", new WaitForSelectorOptions { Visible = true });
                if (navBar == null)
                {
                    AddLogs("Stop Scrape", "Header Tidak Ditemukan");
                    isStopped = true;
                    return;
                }

                Step = 2; // Button Login
                var btnLogin = await Page.XPathAsync(".//button[contains(text(), 'Login') ]");
                if (btnLogin.Length > 0)
                {
                    await btnLogin[0].EvaluateFunctionAsync("e => e.click()");

                    Step = 3; // Box Login
                    var boxLogin = await Page.WaitForXPathAsync("//iframe[@id='all-iframe']");
                    if (boxLogin != null)
                    {
                        var Iframe = await boxLogin.ContentFrameAsync(); // Handle Iframe Login Puppeteer

                        await Task.Delay(3000); // Tunggu Sebentar Selagi Puppeteer Meng-Handle Iframe

                        Step = 4; // Memasukan Username
                        var inputUsername = await Iframe.WaitForSelectorAsync("input[id='input-1']");
                        if (inputUsername != null)
                        {
                            await inputUsername.TypeAsync(Username, new TypeOptions { Delay = 100 });

                            await Task.Delay(3000);

                            Step = 5; // Masukan Password
                            var inputPassword = await Iframe.WaitForSelectorAsync("input[id='input-2']");
                            if (inputPassword != null)
                            {
                                await inputPassword.TypeAsync(Password, new TypeOptions { Delay = 100 });

                                await Task.Delay(3000);

                                Step = 6; // Tekan Enter / Press Enter
                                await inputPassword.PressAsync("Enter");

                                await Task.Delay(8000);

                                Step = 7;
                                var validLogin = await Page.WaitForXPathAsync("//div[@class='dropdown header-account-dropdown']");
                                if (validLogin != null)
                                {
                                    AddLogs("Login", $"Berhasil Login {website}");
                                    loginTrue = true;
                                }
                            }
                        }
                    }
                }
                else
                {
                    AddLogs("Login", $"Gagal Login {website}");
                }
            }
            catch (Exception ex)
            {
                AddLogs("Error", $"Auto Login {Step}, {ex}");
            }
        }

        #endregion Logic Scrape
    }

    public class Data
    {
        public string Unik { get; set; }
        public string UrlPemasang { get; set; }
        public string ExtId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Category { get; set; }
        public string Photo { get; set; }
        public string Address { get; set; }
        public string LocatedIn { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string Rating { get; set; }
        public string Reviews { get; set; }
        public string Postal { get; set; }
        public string Phone2 { get; set; }
        public string ExtSites { get; set; }
        public string Url { get; set; }
        public string Search { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string OpenHours { get; set; }
        public string Location { get; set; }
    }

    public class Payload
    {
        public string Url { get; set; }
        public string Id { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }
    }

    public class Respond
    {
        public string text { get; set; }
    }
}