using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Offerte
{
    //QUesto programma crea una directory conenente dei file preimpostati per la redazione di offerte e report
    //Se si riscontrano degli errori verificare che le impostazioni (Solution Explorer > Offerte > Proprietà > Settings) siano corrette per il computer in uso
    //Utilizzo: selezionare un azienda, compilare i campi desiderati e premere crea

    public partial class MainForm : Form
    {
        private static Caricamentocs carica = null;
        string nomeAzienda = "";
        //Liste dei dati dei clienti
        List<string> nAziende = new List<string>();
        List<string> Indirizzi = new List<string>();
        List<string> Citta = new List<string>();
        List<string> Cap = new List<string>();
        List<string> CondizioniPagamento = new List<string>();


        public MainForm()
        {
            InitializeComponent();
        }

        //Carica i dati di ogni cliente nelle rispettive liste
        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                textBoxAnno.Text = DateTime.Now.Year.ToString();

                var listaClienti = Provider.ClienteProvider.NomiAziende();

                foreach (var item in listaClienti)
                {
                    //Rimuove SRL con o senza punti
                    item.RagioneSociale = Regex.Replace(item.RagioneSociale, @" s\.?r\.?l\.?", "", RegexOptions.IgnoreCase);
                    //Rimuove SPA con o senza punti
                    item.RagioneSociale = Regex.Replace(item.RagioneSociale, @" s\.?p\.?a\.?", "", RegexOptions.IgnoreCase);
                    nAziende.Add(item.RagioneSociale.Trim());

                    Indirizzi.Add(item.Indirizzo.Trim() + (item.NumeroCivico == null ? "" : " " + item.NumeroCivico.Trim()));

                    Cap.Add(item.Cap.Trim());

                    Citta.Add(item.Citta.Trim());

                    CondizioniPagamento.Add(item.CondizionePagamento.Trim());
                }

                //Autocomplete per i nomi delle aziende
                comboBoxNomeAzienda.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBoxNomeAzienda.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection data = new AutoCompleteStringCollection();
                foreach (var item in nAziende)
                {
                    data.Add(item.Trim());
                }
                comboBoxNomeAzienda.AutoCompleteCustomSource = data;
                comboBoxNomeAzienda.DataSource = data;
            } catch(Exception ex)
            {
                MessageBox.Show("Errore nel caricamento dei dati\n" + ex.StackTrace);
            }
        }

        //Modifica il file .doc generico di offerta inserendo i dati forniti
        public void ScriviSuOfferta(Spire.Doc.Document documento, string path, int nofferta, string datastring, string condizionePagamento)
        {
            documento.LoadFromFile(path + "\\" + "Offerta_" + nofferta.ToString("000") + "-" + DateTime.Today.Year.ToString() + "_" + nomeAzienda + "_" + textBoxDescrizioneCartella.Text + ".doc");
            documento.Replace("Azienda", nomeAzienda, false, true);
            documento.Replace("Indirizzo", textBoxIndirizzo.Text, false, true);
            documento.Replace("12050,", textBoxCAP.Text, false, true);
            documento.Replace("Nome Cognome", textBoxAttenzioneDi.Text, false, true);
            documento.Replace("Città", "", false, true);
            documento.Replace("27 luglio 2022", datastring, false, true);
            documento.Replace("000/", nofferta.ToString() + "/", false, true);
            documento.Replace("/2022", "/" + DateTime.Now.Year, false, true);
            documento.Replace("Sistema di visione per controlli qualità Ceme nuclei mobili", textBoxDescrizioneCartella.Text, false, true);
            documento.Replace("CONDIZIONE_PAGAMENTO", condizionePagamento, false, true);
            documento.SaveToFile(path + "\\" + "Offerta_" + nofferta.ToString("000") + "-" + DateTime.Today.Year.ToString() + "_" + nomeAzienda + "_" + textBoxDescrizioneCartella.Text + ".doc");
        }

        //Modifica il file .odt generico di report inserendo i dati forniti
        public void ScriviSuReport(Spire.Doc.Document documento, string path, int nofferta, string datastring)
        {
            documento.LoadFromFile(path + "\\report\\" + "Report_" + nofferta.ToString("000") + "-" + DateTime.Today.Year.ToString() + "_" + nomeAzienda + "_" + textBoxDescrizioneCartella.Text + ".odt");
            documento.Replace("Azienda", nomeAzienda, false, true);
            documento.Replace("Indirizzo", textBoxIndirizzo.Text, false, true);
            documento.Replace("12050,", textBoxCAP.Text, false, true);
            documento.Replace("Nome Cognome", textBoxAttenzioneDi.Text, false, true);
            documento.Replace("Città", "", false, true);
            documento.Replace("27 luglio 2022", datastring, false, true);
            documento.Replace("000/", nofferta.ToString() + "/", false, true);
            documento.Replace("/2022", "/" + DateTime.Now.Year, false, true);
            documento.Replace("Nome tecnico “NON METTERE IL COGNOME PER PRIVACY”", textBoxNomeTecnico.Text, false, true);
            documento.SaveToFile(path + "\\report\\" + "Report_" + nofferta.ToString("000") + "-" + DateTime.Today.Year.ToString() + "_" + nomeAzienda + "_" + textBoxDescrizioneCartella.Text + ".odt");
        }

        //Rimuove i caratteri non validi
        public static string CleanInput(string strIn)
        {
            try
            {
                return Regex.Replace(strIn, @"[^\w\.@-]", " ", RegexOptions.None, TimeSpan.FromSeconds(1));
            }
            catch (RegexMatchTimeoutException)
            {
                return String.Empty;
            }
        }

        //Avvia un Thread che crea una copia della directory generica e successivamente avvia due Task che vanno ad adattare i file generici con le informazioni fornite
        private void buttonCrea_Click(object sender, EventArgs e)
        {
            textBoxDescrizioneCartella.Text = CleanInput(textBoxDescrizioneCartella.Text);
            textBoxNomeTecnico.Text = CleanInput(textBoxNomeTecnico.Text);
            textBoxIndirizzo.Text = CleanInput(textBoxIndirizzo.Text);
            textBoxAttenzioneDi.Text = CleanInput(textBoxAttenzioneDi.Text);
            textBoxCAP.Text = CleanInput(textBoxCAP.Text);
            textBoxCondizionePagamento.Text = CleanInput(textBoxCondizionePagamento.Text);

            try
            {
                Thread splashThread = new Thread(new ThreadStart(
                     delegate
                     {
                         carica = new Caricamentocs();
                         Application.Run(carica);
                     }
                     ));

                splashThread.SetApartmentState(ApartmentState.STA);
                splashThread.Start();

                Thread.Sleep(50);

                int nofferta = 1;
                nomeAzienda = comboBoxNomeAzienda.Text.Trim();
                List<int> ris2 = new List<int>();
                string[] pathServer = Directory.GetDirectories(Properties.Settings.Default.PathServer + "\\" + textBoxAnno.Text, "*_*");
                for (int i = 0; i < pathServer.Length; i++)
                {
                    string[] ris1 = pathServer[i].Split('\\');
                    string[] ris3 = (ris1[ris1.Length - 1].Split('_'));
                    if (Convert.ToInt32(ris3[0]) != 999)
                    {
                        ris2.Add(Convert.ToInt32(ris3[0]));
                    }
                }

                if (ris2.Count == 0)
                {
                    nofferta = 1;
                }
                else
                {
                    nofferta = ris2.Last() + 1;
                }

                string descrizione = textBoxDescrizioneCartella.Text;
                DateTime data = DateTime.Today;
                string path = Properties.Settings.Default.PathServer + "\\" + textBoxAnno.Text + "\\" + nofferta.ToString("000") + "_" + nomeAzienda + "_" + textBoxDescrizioneCartella.Text;
                String dataString = data.ToString("dd MMMM yyyy");
                string condizionePagamento = textBoxCondizionePagamento.Text;
                CopyFilesRecursively(Properties.Settings.Default.PathServer + "\\" + Properties.Settings.Default.CartellaMaster, path, ref nofferta, ref nomeAzienda, ref descrizione);
                Directory.CreateDirectory(path);

                //Task che modifica il documento di offerta generico
                System.Threading.Tasks.Task T_Offerta = System.Threading.Tasks.Task.Run(() =>
                {
                    try
                    {
                        Spire.Doc.Document Offerta = new Spire.Doc.Document();
                        ScriviSuOfferta(Offerta, path, nofferta, dataString, condizionePagamento);
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.ToString());
                    }

                });

                //Task che modifica il documento di report generico
                System.Threading.Tasks.Task T_Report = System.Threading.Tasks.Task.Run(() =>
                {
                    try
                    {
                        Spire.Doc.Document Report = new Spire.Doc.Document();
                        ScriviSuReport(Report, path, nofferta, dataString);
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.ToString());
                    }
                });

                System.Threading.Tasks.Task.WaitAll(T_Offerta, T_Report);

                if (carica != null)
                {
                    carica.Invoke(new Action(() =>
                    {
                        carica?.Close();
                        carica = null;
                    }));
                }

                textBoxDescrizioneCartella.Clear();
                textBoxNomeTecnico.Clear();

                MessageBox.Show("Report e offerta generate con successo.");

                Process.Start("explorer.exe", path);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //Copia i file generici nella nuova directory
        private static void CopyFilesRecursively(string sourcePath, string targetPath, ref int nofferta, ref string val1, ref string descrizione)
        {
            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
            {
                if (newPath == Properties.Settings.Default.PathServer + "\\" + Properties.Settings.Default.CartellaMaster + "\\" + Properties.Settings.Default.FileOfferte)
                    File.Copy(newPath, newPath.Replace(sourcePath + "\\" + Properties.Settings.Default.FileOfferte, targetPath + "\\" + "Offerta_" + nofferta.ToString("000") + "-" + DateTime.Today.Year.ToString() + "_" + val1 + "_" + descrizione + ".doc"), true);
                else if (newPath == Properties.Settings.Default.PathServer + "\\" + Properties.Settings.Default.CartellaMaster + "\\report\\" + Properties.Settings.Default.FileReport)
                    File.Copy(newPath, newPath.Replace(sourcePath + "\\report\\" + Properties.Settings.Default.FileReport, targetPath + "\\" + "report" + "\\" + "Report_" + nofferta.ToString("000") + "-" + DateTime.Today.Year.ToString() + "_" + val1 + "_" + descrizione + ".odt"), true);
                else
                    File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
            }
        }

        //Aggiorna i dati se si cambia l'azienda selezionata nel comboBox
        private void comboBoxNomeAzienda_SelectedValueChanged(object sender, EventArgs e)
        {
            textBoxIndirizzo.Text = Indirizzi[comboBoxNomeAzienda.SelectedIndex];
            textBoxCAP.Text = Cap[comboBoxNomeAzienda.SelectedIndex];
            textBoxCitta.Text = Citta[comboBoxNomeAzienda.SelectedIndex];
            textBoxCondizionePagamento.Text = CondizioniPagamento[comboBoxNomeAzienda.SelectedIndex];
        }

        //Apre il form contenente il video esplicativo
        private void btnInfo_Click(object sender, EventArgs e)
        {
            INFO info = new INFO();
            info.ShowDialog();
        }

        //Chiude il form
        private void buttonAnnulla_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}