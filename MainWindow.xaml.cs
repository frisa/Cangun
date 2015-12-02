using System;
using System.Collections.Generic;
using System.Linq;
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
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Threading;
using vxlapi_NET20;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Specialized;
using System.Windows.Threading;
using System.Data;
using System.Data.OleDb;


namespace cangun
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }
    }
    public static class ObjectCopier
    {
        public static T Clone<T>(T source)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("The type must be serializable.", "source");
            }
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }
    }

public static class CProjectDatabase
    {
        private static int _cntPrj = 0;
        private static int _cntSeq = 0;
        public static string getProjectName()
        {
            return String.Format("Project{0}",_cntPrj++);
        }
        public static string getSequenceName()
        {
            return String.Format("Sequence{0}", _cntSeq++);
        }
    }

[Serializable]public class CMR : INotifyPropertyChanged
{
    public string _number;
    public string _title;
    public string _content;
    public string _state;
    public string _file;
    public string _project;
    public string _author;
    public ObservableCollection<CMRComment> _comments;
    public ObservableCollection<CMRCcb> _ccb;
    public ObservableCollection<CMRMeasurement> _meas;

    public string Number
    {
        get { return _number; }
        set
        {
            _number = value;
            RaisePropertyChanged("Number");
        }
    }
    public string Title
    {
        get { return _title; }
        set
        {
            _title= value;
            RaisePropertyChanged("Title");
        }
    }
    public string Content
    {
        get { return _content; }
        set
        {
            _content = value;
            RaisePropertyChanged("Content");
        }
    }
    public string Project
    {
        get { return _project; }
        set
        {
            _project = value;
            RaisePropertyChanged("Project");
        }
    }
    public string State
    {
        get { return _state; }
        set
        {
            _state = value;
            RaisePropertyChanged("State");
        }
    }
    public string File
    {
        get { return _state; }
        set
        {
            _state = value;
            RaisePropertyChanged("File");
        }
    }
    public string Author
    {
        get { return _author; }
        set
        {
            _author = value;
            RaisePropertyChanged("Author");
        }
    }
    public ObservableCollection<CMRComment> Comments 
    {
        get { return _comments; }
        set
        {
            _comments = value;
            RaisePropertyChanged("Comments");
        }
    }
    public ObservableCollection<CMRCcb> CCBs
    {
        get { return _ccb; }
        set
        {
            _ccb = value;
            RaisePropertyChanged("CCBs");
        }
    }
    public ObservableCollection<CMRMeasurement> Measurements
    {
        get { return _meas; }
        set
        {
            _meas = value;
            RaisePropertyChanged("Measurements");
        }
    }
    [field: NonSerialized]
    public event PropertyChangedEventHandler PropertyChanged;
    private void RaisePropertyChanged(string propertyName)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null)
        {
            handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

[Serializable]public class CMRComment : INotifyPropertyChanged
{
    public string _modul;
    public string _comment;
    public string _author;
    public string Modul
    {
        get { return _modul; }
        set
        {
            _modul = value;
            RaisePropertyChanged("Modul");
        }
    }
    public string Comment
    {
        get { return _comment; }
        set
        {
            _comment = value;
            RaisePropertyChanged("Comment");
        }
    }
    public string Author
    {
        get { return _author; }
        set
        {
            _author = value;
            RaisePropertyChanged("Author");
        }
    }
    [field: NonSerialized]
    public event PropertyChangedEventHandler PropertyChanged;
    private void RaisePropertyChanged(string propertyName)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null)
        {
            handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
[Serializable]public class CMRCcb : INotifyPropertyChanged
{
    public string _state;
    public string _result;
    public string _author;
    public string Author
    {
        get { return _author; }
        set
        {
            _author = value;
            RaisePropertyChanged("Author");
        }
    }
    public string State
    {
        get { return _state; }
        set
        {
            _state = value;
            RaisePropertyChanged("State");
        }
    }
    public string Result
    {
        get { return _result; }
        set
        {
            _result = value;
            RaisePropertyChanged("Result");
        }
    }
    [field: NonSerialized]
    public event PropertyChangedEventHandler PropertyChanged;
    private void RaisePropertyChanged(string propertyName)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null)
        {
            handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
[Serializable]public class CMRMeasurement : INotifyPropertyChanged
{
    public string _state;
    public string _module;
    public string _author;
    public string Author
    {
        get { return _author; }
        set
        {
            _author = value;
            RaisePropertyChanged("Author");
        }
    }
    public string State
    {
        get { return _state; }
        set
        {
            _state = value;
            RaisePropertyChanged("State");
        }
    }
    public string Module
    {
        get { return _module; }
        set
        {
            _module = value;
            RaisePropertyChanged("Module");
        }
    }
    [field: NonSerialized]
    public event PropertyChangedEventHandler PropertyChanged;
    private void RaisePropertyChanged(string propertyName)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null)
        {
            handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

[Serializable]public class CProject : INotifyPropertyChanged
    {
        public string _name;
        public string _pathDbc;
        public string _description;
        public string _pathMRDB; 
        public string Name
        {
            get { return _name; }
            set { _name = value;}
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public string PathDbc 
        {
            get { return _pathDbc; }
            set {
                _pathDbc = value;
                RaisePropertyChanged("PathDbc");
            }
        }
        public string PathMRDB
        {
            get { return _pathMRDB; }
            set
            {
                _pathMRDB = value;
                RaisePropertyChanged("PathMRDB");
            }
        }
        public DataTable dtMRs;
        public DataTable dtMRsFav; 

        [field: NonSerialized] public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
[Serializable]public class CProjectViewModel: INotifyPropertyChanged
    {
    private CProject _project;
    private String _sConnectionString;
    static private String _filterTitelString = String.Empty ;
    static private String _filterContentString = String.Empty;
    static private String _filterMrString = String.Empty;
    static private String _filterStatus =  "   ";
    private String _filterConstantString;
    static private String _filterOutString = "n/a";
    
    [field: NonSerialized] private DataRowView _drvMR;
    [field: NonSerialized] private CMR _actualMR = new CMR();
        private CProject Project
        {
            get { return _project; }
            set { _project = value; }
        }
        public string ProjectName
        {
            get { return Project.Name; }
            set 
            { 
                Project.Name = value;
                RaisePropertyChanged("ProjectName");
            }
        }
        public string ProjectPathMRDB
        {
            get { return Project.PathMRDB; }
            set
            {
                Project.PathMRDB = value;
                RaisePropertyChanged("ProjectPathMRDB");
            }
        }
        public DataTable ProjectDtMRs
        {
            get { return Project.dtMRs; }
            set
            {
                Project.dtMRs = value;
                RaisePropertyChanged("ProjectDtMRs");
            }
        }
        public DataTable ProjectDtMRsFav
        {
            get { return Project.dtMRsFav; }
            set
            {
                Project.dtMRsFav = value;
                RaisePropertyChanged("ProjectDtMRsFav");
            }
        }
        public DataRowView drvMR
        {
            get { return _drvMR; }
            set
            {
                if (value != null)
                {
                    _drvMR = value;
                    if (ActualMR == null) ActualMR = new CMR();
                    ActualMR.Number = _drvMR["MeldungsNr"].ToString();
                    ActualMR.Title  = _drvMR["Titel"].ToString();
                    ActualMR.Content = _drvMR["Inhalt"].ToString();
                    ActualMR.Project = _drvMR["Produkt"].ToString();
                    ActualMR.Author = _drvMR["MitarbeiterKurzname"].ToString();
                    ActualMR.State = _drvMR["Zustand"].ToString();
                    ActualMR.File = _drvMR["Bezugsdokument"].ToString();

                    OleDbDataAdapter daComments = new OleDbDataAdapter("SELECT MitarbeiterKurzname, Stellungnahme, SWBaustein FROM [Stellungnahme Entwicklung] WHERE MeldungsNr=" + ActualMR.Number, _sConnectionString);
                    OleDbDataAdapter daMeassurement = new OleDbDataAdapter("SELECT MES_Author, MES_Module, MES_done FROM [MR_Measurements] WHERE MeldungsNr=" + ActualMR.Number, _sConnectionString);
                    OleDbDataAdapter daCcb = new OleDbDataAdapter("SELECT Teilnehmer, Ergebnis FROM [CCBEntscheid] WHERE MeldungsNr=" + ActualMR.Number, _sConnectionString);
 
                    DataTable dtComments = new DataTable();
                    DataTable dtCcb = new DataTable();
                    DataTable dtMeassurement = new DataTable();
                    try
                    {
                        daComments.Fill(dtComments);
                        daCcb.Fill(dtCcb);
                        daMeassurement.Fill(dtMeassurement);
                        ActualMR.Comments = new ObservableCollection<CMRComment>();
                        ActualMR.CCBs = new ObservableCollection<CMRCcb>();
                        ActualMR.Measurements = new ObservableCollection<CMRMeasurement>();
                        foreach (DataRow dr in dtComments.Rows)
                        {
                            CMRComment iComment = new CMRComment();
                            iComment.Author = dr["MitarbeiterKurzname"].ToString();
                            iComment.Comment = dr["Stellungnahme"].ToString();
                            iComment.Modul = dr["SWBaustein"].ToString();
                            ActualMR.Comments.Add(iComment);
                        }
                        foreach (DataRow dr in dtCcb.Rows)
                        {
                            CMRCcb iCcb = new CMRCcb();
                            iCcb.Author  = dr["Teilnehmer"].ToString();
                            //iCcb.State   = dr["CCB-Entscheid"].ToString();
                            iCcb.Result  = dr["Ergebnis"].ToString();
                            ActualMR.CCBs.Add(iCcb);
                        }
                        foreach (DataRow dr in dtMeassurement.Rows)
                        {
                            CMRMeasurement iMeas = new CMRMeasurement();
                            iMeas.Author  = dr["MES_Author"].ToString();
                            iMeas.Module = dr["MES_Module"].ToString();
                            iMeas.State = dr["MES_done"].ToString();
                            ActualMR.Measurements.Add(iMeas);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        public CMR  ActualMR 
        {
            get
            {
                return _actualMR;
            }
            set
            {
                _actualMR = value;
                RaisePropertyChanged("ActualMR");
            }
        }
        public string ProejctDescription
        {
            get { return _project.Description; }
            set { _project.Description = value; }
        }
        public string ProjectPathDbc
        {
            get { return _project.PathDbc; }
            set {
                _project.PathDbc = value;
                RaisePropertyChanged("ProjectPathDbc");
            }
        }
        public CProjectViewModel()
        {
            _project = new CProject();
        }
        
        AsyncObservableCollection<CMessageViewModel> _messages = new AsyncObservableCollection<CMessageViewModel>();
        public AsyncObservableCollection<CMessageViewModel> Messages
        {
            get { return _messages; }
            set { _messages=value; }
        }

        ObservableCollection<CSequenceViewModel> _sequences = new ObservableCollection<CSequenceViewModel>();
        public ObservableCollection<CSequenceViewModel> Sequences
        {
            get { return _sequences; }
            set { _sequences = value; }
        }

        [field:NonSerialized] public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ICommand UpdateProjectName { get { return new CRelatedCommandNoParam(UpdateProjectNameExecute, CanUpdateProjectNameExecute); } }
        void UpdateProjectNameExecute()
        {
            this.ProjectName = CProjectDatabase.getProjectName();
        }
        bool CanUpdateProjectNameExecute()
        {
            return true;
        }
        public ICommand AddMessage { get { return new CRelatedCommandParam(AddCustomMessageExecute, CanAddCustomMessageExecute); } }
        void AddCustomMessageExecute(object name)
        {
            _messages.Add(new CMessageViewModel() {MessageId = 1, MessageName=(String)name , MessageDlc = 8, MessageEcu = "Ecu", MessageData=new byte[]{0,1,2,3,4,5,6,7}});
        }
        bool CanAddCustomMessageExecute()
        {
            return true;
        }
        public ICommand LoadDbc { get { return new CRelatedCommandNoParam(LoadDbcExecute, CanLoadDbcExecute); } }
        void LoadDbcExecute()
        {
            try
            {
                FilterOutString = "Loading database";
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.DefaultExt = ".dbc";
                dlg.Filter = "DBC Files (*.dbc)|*.dbc";
                if (dlg.ShowDialog() == true)
                {
                    String sPath = dlg.FileName;
                    if (System.IO.File.Exists(sPath))
                    {
                        const string MESSAGES_EXP = @"BO_ (?<message_id>[0-9]+) (?<message_name>[a-zA-Z0-9_]+): (?<message_dlc>[0-8]) (?<message_ecu>[a-zA-Z0-9_]+)\r\n(?<message_signals>( SG_[^\r\n]+\r\n)+)";
                        const string SIGNALS_EXP = @"SG_ (?<signal_name>[a-zA-Z0-9_]+)(?<signal_sbit>[a-zA-Z0-9_ ]*): (?<signal_sbit>[0-9]+)\|(?<signal_len>[0-9]+)\@(?<signal_intel>[0-9]+)(?<signal_signed>[\+\-]+)";
                                             
                        StreamReader sr = new StreamReader(sPath);
                        String FileContent = sr.ReadToEnd();
                        MatchCollection mcMessages = Regex.Matches(FileContent, MESSAGES_EXP, RegexOptions.Multiline);
                        Match mComment;
                        Int64 i64MsgId;
                        string sCommentPattern;
                        _messages.Clear();
                        foreach (Match mMessages in mcMessages)
                        {
                            CMessageViewModel oMsvm = new CMessageViewModel();
                            i64MsgId = Convert.ToInt64(mMessages.Groups["message_id"].Value);
                            if (i64MsgId == 1414)
                            {
 
                            }
                            if (i64MsgId <= Int32.MaxValue)
                            {
                                oMsvm.MessageId = Convert.ToInt32(i64MsgId);
                                oMsvm.MessageName = Convert.ToString(mMessages.Groups["message_name"].Value);
                                oMsvm.MessageDlc = Convert.ToInt32(mMessages.Groups["message_dlc"].Value);
                                oMsvm.MessageEcu = Convert.ToString(mMessages.Groups["message_ecu"].Value);
                                oMsvm.MessageData = new byte[oMsvm.MessageDlc];
                                sCommentPattern = @"CM_ BO_ " + mMessages.Groups["message_id"].Value.ToString() + @" ""(?<message_comment>.*)""";
                                mComment = Regex.Match(FileContent, sCommentPattern);
                                if (mComment.Success)
                                    oMsvm.MessageComment = mComment.Groups["message_comment"].Value;
                                MatchCollection mcSignals = Regex.Matches(mMessages.Groups["message_signals"].ToString(), SIGNALS_EXP, RegexOptions.Multiline);
                                foreach (Match mSignals in mcSignals)
                                {
                                    CSignalViewModel oSigvm = new CSignalViewModel();
                                    oSigvm.SignalName = Convert.ToString(mSignals.Groups["signal_name"].Value);
                                    oSigvm.SignalStartBit = Convert.ToInt32(mSignals.Groups["signal_sbit"].Value);
                                    oSigvm.SignalLenght = Convert.ToInt32(mSignals.Groups["signal_len"].Value);
                                    oSigvm.SignalIntel = Convert.ToString(mSignals.Groups["signal_intel"].Value);
                                    oSigvm.SignalSigned = Convert.ToString(mSignals.Groups["signal_signed"].Value);
                                    sCommentPattern = @"CM_ SG_ " + mMessages.Groups["message_id"].Value.ToString() + @" " + mSignals.Groups["signal_name"].Value.ToString() + @" ""(?<signal_comment>.*)""";
                                    mComment = Regex.Match(FileContent, sCommentPattern);
                                    if (mComment.Success)
                                        oSigvm.SignalComment = mComment.Groups["signal_comment"].Value;
                                    oMsvm.Signals.Add(oSigvm);
                                }
                                this.Messages.Add(oMsvm);
                            }
                        }
                        ProjectPathDbc = (String)sPath;
                    }
                    else
                    {
                        MessageBox.Show(String.Format("The File {0} does not exist", sPath));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            FilterOutString = "Database loaded";
        }
        bool CanLoadDbcExecute()
        {
            return true;
        }
        public ICommand AddSequence { get { return new CRelatedCommandNoParam(AddSequenceExecute, CanAddSequenceExecute); } }
        void AddSequenceExecute()
        {
            _sequences.Add(new CSequenceViewModel() { SequenceName = CProjectDatabase.getSequenceName() });
        }
        bool CanAddSequenceExecute()
        {
            return true;
        }
        public ICommand LoadMRDB { get { return new CRelatedCommandParam(LoadMRDBExecute, CanLoadMRDBExecute); } }
        public ICommand Filter { get { return new CRelatedCommandNoParam(FilterExecute, CanFilterExecute); } }
        public ICommand AddToFav { get { return new CRelatedCommandNoParam(AddToFavExecute, CanAddToFavExecute); } }
        bool CanAddToFavExecute()
        {
            return true;
        }
        void AddToFavExecute()
        {
            if (null == ProjectDtMRsFav)
            {
                ProjectDtMRsFav = new DataTable("MR Favourites");
                ProjectDtMRsFav.Columns.Add("MeldungsNr");
                ProjectDtMRsFav.Columns.Add("Titel");
                ProjectDtMRsFav.Columns.Add("Inhalt");
                ProjectDtMRsFav.Columns.Add("Produkt");
                ProjectDtMRsFav.Columns.Add("MitarbeiterKurzname");
                ProjectDtMRsFav.Columns.Add("Zustand");
            }
            DataRow newRow = ProjectDtMRsFav.NewRow();
            newRow["MeldungsNr"] = _actualMR._number;
            newRow["Titel"] = _actualMR._title;
            newRow["Inhalt"] = _actualMR._content;
            newRow["Produkt"] = _actualMR._project;
            newRow["MitarbeiterKurzname"] = _actualMR._author;
            newRow["Zustand"] = _actualMR._state;
            ProjectDtMRsFav.Rows.Add(newRow);
        }
        public ICommand ClearFilter { get { return new CRelatedCommandNoParam(ClearFilterExecute, CanClearFilterExecute); } }
        public string FilterMrString
        {
            get { return _filterMrString; }
            set
            {
                _filterMrString = value;
                RaisePropertyChanged("FilterMrString");
                RaiseFilter();
            }
        }
        public string FilterTitelString
        {
            get { return _filterTitelString; }
            set
            {
                _filterTitelString = value;
                RaisePropertyChanged("FilterTitelString");
                RaiseFilter();
            }
        }
        public string FilterContentString
        {
            get { return _filterContentString; }
            set
            {
                _filterContentString = value;
                RaisePropertyChanged("FilterContentString");
                RaiseFilter();
            }
        }
        public string FilterConstantString
        {
            get { return _filterConstantString; }
            set
            {
                _filterConstantString = value;
                RaisePropertyChanged("FilterConstantString");
                RaiseFilter();
            }
        }
        public string FilterOutString
        {
            get { return _filterOutString; }
            set
            {
                _filterOutString = value;
                RaisePropertyChanged("FilterOutString");
            }
        }
        public string FilterStatus
        {
            get { return _filterStatus; }
            set
            {
                _filterStatus = value;
                RaisePropertyChanged("FilterStatus");
                RaiseFilter();
            }
        }
        private void RaiseFilter()
        {
            if (null != ProjectDtMRs)
            {
                DataView dv = ProjectDtMRs.DefaultView;
                String sFilterString = String.Empty; 
                try
                {
                    if (!String.IsNullOrWhiteSpace(_filterConstantString))
                        sFilterString = sFilterString + _filterConstantString + " AND ";

                    if (!String.IsNullOrWhiteSpace(_filterMrString))
                        sFilterString = sFilterString + "MrNr LIKE '%" + _filterMrString + "%' AND ";

                    sFilterString = sFilterString + "Titel LIKE '%" + _filterTitelString + "%' AND " +
                                    "Inhalt LIKE '%" + _filterContentString + "%'";
                    if (!String.IsNullOrWhiteSpace(_filterStatus.Substring(_filterStatus.Length - 3, 3)))
                        sFilterString = sFilterString + " AND Zustand LIKE '" + _filterStatus.Substring(_filterStatus.Length -3,3)  + "'";
                    dv.RowFilter = sFilterString;
                    RaisePropertyChanged("ProjectDtMRs");
                }
                catch (Exception ex)
                {
                    FilterOutString = ex.Message + "FilStr: " + sFilterString;
                }
            }
        }
        void FilterExecute()
        {
            RaiseFilter();
            FilterOutString = "Filter executed";
        }
        bool CanFilterExecute()
        {
            return true;
        }
        void ClearFilterExecute()
        {
            FilterMrString = "";
            FilterTitelString = "";
            FilterContentString = "";
            FilterStatus = "   ";
            RaiseFilter();
            FilterOutString = "Filter cleared";
        }
        bool CanClearFilterExecute()
        {
            return true;
        }
        void LoadMRDBExecute(object pathMRDB)
        {
            try
            {
                String sPathMRDB = pathMRDB.ToString();
                if (File.Exists(sPathMRDB))
                {
                    _sConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + sPathMRDB + ";";
                    OleDbDataAdapter da = new OleDbDataAdapter("SELECT MeldungsNr, Titel, Produkt, Inhalt, MitarbeiterKurzname, Zustand, Bezugsdokument  FROM MRAntrag", _sConnectionString);

                    ProjectDtMRs = new DataTable();
                    da.Fill(ProjectDtMRs);
                    ProjectDtMRs.Columns.Add("MrNr");
                    foreach (DataRow row in ProjectDtMRs.Rows)
                    {
                        row["MrNr"] = row["MeldungsNr"].ToString();
                    }
                    RaisePropertyChanged("ProjectDtMRs");
                }
                else
                {
                    MessageBox.Show(String.Format("The File {0} does not exist", sPathMRDB));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        bool CanLoadMRDBExecute()
        {
            return true;
        }
     }
[Serializable]public class CRelatedCommandNoParam : ICommand
     {
        readonly Func<Boolean> _canExecute;
        readonly Action _execute;
        public CRelatedCommandNoParam(Action execute): this(execute, null)
        {
        }
        public CRelatedCommandNoParam(Action execute, Func<Boolean> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute;
            _canExecute = canExecute;
        }
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute();
        }
        public event EventHandler CanExecuteChanged
        {
            add
            {

                if (_canExecute != null)
                    CommandManager.RequerySuggested += value;
            }
            remove
            {

                if (_canExecute != null)
                    CommandManager.RequerySuggested -= value;
            }
        }
        public void Execute(Object parameter)
        {
            _execute();
        }
    }
[Serializable]public class CRelatedCommandParam : ICommand
    {
        readonly Func<Boolean> _canExecute;
        readonly Action<object> _execute;
        public CRelatedCommandParam(Action<object> execute): this(execute, null)
        {
        }
        public CRelatedCommandParam(Action<object> execute, Func<Boolean> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute;
            _canExecute = canExecute;
        }
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute();
        }
        public event EventHandler CanExecuteChanged
        {
            add
            {

                if (_canExecute != null)
                    CommandManager.RequerySuggested += value;
            }
            remove
            {

                if (_canExecute != null)
                    CommandManager.RequerySuggested -= value;
            }
        }
        public void Execute(Object parameter)
        {
            _execute(parameter);
        }
    }
[Serializable]public class CSolutionViewModel : INotifyPropertyChanged
    {
        private string _path;
        private string _description;
        private int _currentTime;
        private int _currentObservationTime;
        private int _clkTimeStart;
        private int _clkTime;
        private bool _clkActive;
        private string _log; 
        private ObservableCollection<CSendetMessageViewModel> _currentSendetMessages = new ObservableCollection<CSendetMessageViewModel>(); 
        private CSequenceViewModel _currentSequenceViewModel;
        private CProjectViewModel _currentProjectViewModel;
        ObservableCollection<CProjectViewModel> _projects = new ObservableCollection<CProjectViewModel>();

        public string Path
        {
            get { return _path; }
            set {
                _path = value;
                RaisePropertyChanged("Path");
            }
        }
        public string SolutionDescription
        {
            get { return _description; }
            set { _description = value; }
        }
        public string SolutionLog
        {
            get { return _log; }
            set { _log = value; }
        }
        public int ClkTime 
        {
            get { return _clkTime; }
            set { 
                _clkTime = value;
                RaisePropertyChanged("ClkTime");
            }
        }
        public bool ClkActive
        {
            get { return _clkActive; }
            set
            {
                _clkActive = value;
                if (_clkActive) 
                    _clkTimeStart = _currentTime;
                RaisePropertyChanged("ClkActive");
            }
        }

        public void log(string message)
        {
            SolutionLog = SolutionLog + message + "\n";
            RaisePropertyChanged("SolutionLog");
        }
        public ObservableCollection<CProjectViewModel> Projects
        {
            get
            {
                return _projects;
            }
            set
            {
                _projects = value;
                RaisePropertyChanged("Projects");
            }
        }
        ObservableCollection<String> _commands = new ObservableCollection<String>();
        ObservableCollection<int> _times = new ObservableCollection<int>();
        ObservableCollection<int> _values = new ObservableCollection<int>();
        public ObservableCollection<String> Commands
        {
            get { return _commands; }
            set { _commands = value; }
        }
        public ObservableCollection<int> Times
        {
            get { return _times; }
            set { _times = value; }
        }
        public ObservableCollection<int> Values
        {
            get { return _values; }
            set { _values = value; }
        }
        public int SolutionCurrentTime
        {
            get { return _currentTime; }
            set 
            {
                _currentTime = value;
                if (_clkActive) ClkTime = _currentTime - _clkTimeStart;
                RaisePropertyChanged("SolutionCurrentTime");
            }
        }
        public int SolutionCurrentObservationTime
        {
            get { return _currentObservationTime; }
            set
            {
                _currentObservationTime = value;
                RaisePropertyChanged("SolutionCurrentObservationTime");
            }
        }
        public CSequenceViewModel SolutionCurrentSequence
        {
            get { return _currentSequenceViewModel; }
            set { _currentSequenceViewModel = value; }
        }
        public CProjectViewModel SolutionCurrentProject
        {
            get { return _currentProjectViewModel; }
            set { _currentProjectViewModel = value; }
        }
        public ObservableCollection<CSendetMessageViewModel> CurrentSendetMessages
        {
            get { return _currentSendetMessages; }
            set { _currentSendetMessages = value; }
        }
        private BackgroundWorker bwTx = new BackgroundWorker();
        private BackgroundWorker bwRx = new BackgroundWorker();

        public CSolutionViewModel()
        {
            _projects.Add(new CProjectViewModel { ProjectName = "Gen4" });
            _projects.Add(new CProjectViewModel { ProjectName = "Gen31" });
            //_projects.Add(new CProjectViewModel { ProjectName = "Roadmap PQ36" });
            //_projects.Add(new CProjectViewModel { ProjectName = "Roadmap AU210" });
            //_projects.Add(new CProjectViewModel { ProjectName = "Roadmap AU316" });

            _commands.Add("Set");
            _commands.Add("Set with ASR");
            _commands.Add("Step 500ms");
            _commands.Add("Timeout");
            _commands.Add("Break");
            _commands.Add("Restart");

            for (int idx=0;idx<100;idx++)
            {
                _times.Add(idx*1000);
            }

            for (int idx = 0; idx < 21; idx++)
            {
                _values.Add(idx);
            }

            _values.Add(50);
            _values.Add(100);
            _values.Add(1000);
            _values.Add(2000);
            _values.Add(3000);
            _values.Add(4000);
            _values.Add(5000);
            _values.Add(10000);

            _currentTime = 0;
        }
        public ICommand Start { get { return new CRelatedCommandNoParam(StartExecute, CanStartExecute); } }

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern int WaitForSingleObject(int handle, int timeOut);

        private XLDriver _xlDriverTx = new XLDriver();
        private int _iEventHandleTx = -1;
        private int _iPortHandleTx = -1;
        UInt64 _ui64TransmitMaskTx = 0;

        private XLDriver _xlDriverRx = new XLDriver();
        private int _iEventHandleRx = -1;
        private int _iPortHandleRx = -1;
        UInt64 _ui64TransmitMaskRx = 0;

        public void xlStartCan(ref int _iEventHandle, ref int _iPortHandle, ref UInt64 _ui64TransmitMask)
        {
            UInt64 ui64AccessMask = 0;
            UInt64 ui64PermissionMask = 0;
            uint uiHWType = 0;
            uint uiHWIndex = 0;
            uint uiHWChannel = 0;
            uint uiBusType = (uint)XLClass.XLbusTypes.XL_BUS_TYPE_CAN;
            uint uiFlags = 0;
            XLClass.XLstatus xlRet;

            if ((_xlDriverTx.XL_GetApplConfig("xlCANSimulator", 0, ref uiHWType, ref uiHWIndex, ref uiHWChannel, uiBusType) != XLClass.XLstatus.XL_SUCCESS) ||
                (_xlDriverTx.XL_GetApplConfig("xlCANSimulator", 1, ref uiHWType, ref uiHWIndex, ref uiHWChannel, uiBusType) != XLClass.XLstatus.XL_SUCCESS))
            {
                _xlDriverTx.XL_SetApplConfig("xlCANSimulator", 0, 0, 0, 0, 0);
                _xlDriverTx.XL_SetApplConfig("xlCANSimulator", 1, 0, 0, 0, 0);
            }
            log("DRIVER-Open xlCANSimulator configuration");
            _xlDriverTx.XL_GetApplConfig("xlCANSimulator", 0, ref uiHWType, ref uiHWIndex, ref uiHWChannel, uiBusType);
            ui64AccessMask |= _xlDriverTx.XL_GetChannelMask((int)uiHWType, (int)uiHWIndex, (int)uiHWChannel);

            ui64PermissionMask = ui64AccessMask;
            _ui64TransmitMaskTx = ui64AccessMask;

            xlRet = _xlDriverTx.XL_OpenPort(ref _iPortHandle, "xlCANSimulator", ui64AccessMask, ref ui64PermissionMask, (uint)1024, uiBusType);
            if (XLClass.XLstatus.XL_SUCCESS != xlRet)
                log("DRIVER-Open port failed");
            else
                log("DRIVER-Open port success");
  
            xlRet = _xlDriverTx.XL_CanRequestChipState(_iPortHandle, ui64AccessMask);
            if (XLClass.XLstatus.XL_SUCCESS != xlRet)
                log("DRIVER-Request chip state failed");
            else
                log("DRIVER-Request chip state success");

            xlRet = _xlDriverTx.XL_ActivateChannel(_iPortHandle, ui64AccessMask, uiBusType, uiFlags);
            if (XLClass.XLstatus.XL_SUCCESS != xlRet)
                log("DRIVER-Activate channel failed");
            else
                log("DRIVER-Activate channel success");
 
            xlRet = _xlDriverTx.XL_SetNotification(_iPortHandle, ref _iEventHandle, 1);
            if (XLClass.XLstatus.XL_SUCCESS != xlRet)
                log("DRIVER-Set notificaiton failed");
            else
                log("DRIVER-Set notificaiton success");
 
            xlRet = _xlDriverTx.XL_ResetClock(_iPortHandle);
            if (XLClass.XLstatus.XL_SUCCESS != xlRet)
                log("DRIVER-Reset clock failed");
            else
                log("DRIVER-Reset clock success");
        }
        private byte[] getMessageValue(byte[] byteMessage, int value, int startBit, int length)
        {
            BitArray bitsMessage = new BitArray(byteMessage);
            BitArray bitsValue = new BitArray(BitConverter.GetBytes(value));
            byte[] byteMessageOut = new byte[byteMessage.Length];
            for (int idx = startBit; idx < (startBit + length); idx++)
            {
                bitsMessage[idx] =  bitsValue[idx - startBit];
            }
            bitsMessage.CopyTo(byteMessageOut,0);
            return byteMessageOut;
        }

        private void bwTx_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Dictionary<int, CSendetMessageViewModel> dicMainCurrentSendetMessages = (Dictionary<int, CSendetMessageViewModel>)e.UserState;
            SolutionCurrentTime = (int)e.ProgressPercentage;
            foreach (KeyValuePair<int, CSendetMessageViewModel> msg in dicMainCurrentSendetMessages)
            {
                if ((SolutionCurrentTime == msg.Value.StartTime) || (SolutionCurrentTime == msg.Value.StopTime))
                {
                    CurrentSendetMessages.Add(new CSendetMessageViewModel(msg.Value.Message, msg.Value.StartTime, msg.Value.StopTime));
                }

            }
        }

        void StartExecute()
        {
            CurrentSendetMessages.Clear(); 
            bwTx.WorkerReportsProgress = true;
            bwTx.WorkerSupportsCancellation = true;
            bwTx.DoWork += delegate(object s, DoWorkEventArgs args)
            {
                CSequenceViewModel sequence=(CSequenceViewModel)args.Argument;
                Dictionary<int, CSendetMessageViewModel> dicCurrentSendetMessages = new Dictionary<int, CSendetMessageViewModel>();
                XLClass.xl_can_message xlMsg = new XLClass.xl_can_message();
                XLClass.xl_event_collection xlEventCollection = new XLClass.xl_event_collection(0);
                XLClass.xl_event xlEvent;
                int time;
                time=0;
                xlStartCan(ref _iEventHandleTx, ref _iPortHandleTx, ref _ui64TransmitMaskTx);
                               
                while(true)
                {
                    if (bwTx.CancellationPending)
                    {
                        _xlDriverTx.XL_ClosePort(_iPortHandleTx);
                        _xlDriverTx.XL_CloseDriver();
                        args.Cancel = true;
                        break;
                    }
                    else
                    {
                        foreach (CStepViewModel step in sequence.Steps)
                        {
                            if (time == step.StepTime)
                            {
                                switch (step.StepCommand)
                                {
                                    case "Set":
                                        {
                                            if (!dicCurrentSendetMessages.ContainsKey(step.StepMessage.MessageId))
                                                dicCurrentSendetMessages.Add(step.StepMessage.MessageId, new CSendetMessageViewModel(step));
                                            dicCurrentSendetMessages[step.StepMessage.MessageId].Message.MessageData = getMessageValue(step.StepMessage.MessageData, step.StepValue, step.StepSignal.SignalStartBit, step.StepSignal.SignalLenght);
                                            dicCurrentSendetMessages[step.StepMessage.MessageId].StartTime = Convert.ToInt32(time);
                                            dicCurrentSendetMessages[step.StepMessage.MessageId].StopTime = Int32.MaxValue;
                                            break;
                                        }
                                    case "Set with ASR":
                                        {

                                            break;
                                        }
                                   
                                    case "Step 500ms":
                                        {
                                            if (!dicCurrentSendetMessages.ContainsKey(step.StepMessage.MessageId))
                                                dicCurrentSendetMessages.Add(step.StepMessage.MessageId, new CSendetMessageViewModel(step));
                                            dicCurrentSendetMessages[step.StepMessage.MessageId].Message.MessageData = getMessageValue(step.StepMessage.MessageData, step.StepValue, step.StepSignal.SignalStartBit, step.StepSignal.SignalLenght);
                                            dicCurrentSendetMessages[step.StepMessage.MessageId].StartTime = time;
                                            dicCurrentSendetMessages[step.StepMessage.MessageId].StopTime = time + 500;
                                            break;
                                        }
                                    case "Timeout":
                                        {
                                            if (dicCurrentSendetMessages.ContainsKey(step.StepMessage.MessageId))
                                                dicCurrentSendetMessages.Remove(step.StepMessage.MessageId);
                                            break;
                                        }
                                    case "Break":
                                        {
                                            if (MessageBox.Show(string.Format("Breaked sequence {0}, do you want to continue?", this.SolutionCurrentSequence.SequenceName), "Break", MessageBoxButton.YesNo, MessageBoxImage.Hand ) != MessageBoxResult.Yes)
                                                return;
                                            break;
                                        }
                                    case "Restart":
                                        {
                                            //RestartExecute();
                                            break;
                                        }
                                    default:
                                        {
                                            break;
                                        }
                                }
                            }
                        }
                        foreach (KeyValuePair<int, CSendetMessageViewModel> msg in dicCurrentSendetMessages)
                        {
                            if (msg.Value.StopTime == time)
                            {
                                msg.Value.Message.MessageData = getMessageValue(msg.Value.Message.MessageData, 0, msg.Value.Signal.SignalStartBit, msg.Value.Signal.SignalLenght);
                            }
                        }
                        xlEventCollection.xlEvent.Clear();
                        foreach (KeyValuePair<int, CSendetMessageViewModel> msg in dicCurrentSendetMessages)
                        {
                            xlEvent = new XLClass.xl_event();
                            xlEvent.tagData.can_Msg.id = (uint)msg.Value.Message.MessageId;
                            xlEvent.tagData.can_Msg.dlc = (ushort)msg.Value.Message.MessageDlc;
                            xlEvent.tagData.can_Msg.data = msg.Value.Message.MessageData;
                            xlEvent.tag = (byte)XLClass.XLeventType.XL_TRANSMIT_MSG;
                            xlEventCollection.xlEvent.Add(xlEvent);
                        }
                        xlEventCollection.messageCount = (uint)xlEventCollection.xlEvent.Count;
                        if (xlEventCollection.messageCount > 0 ) 
                                _xlDriverTx.XL_CanTransmit(_iPortHandleTx, _ui64TransmitMaskTx, xlEventCollection);
                    }
                    bwTx.ReportProgress(time++, dicCurrentSendetMessages);
                    Thread.Sleep(1);
                }
            };
            bwTx.ProgressChanged += bwTx_ProgressChanged;
            CurrentSendetMessages.Clear();
            bwTx.RunWorkerAsync(this._currentSequenceViewModel);
        }
        bool CanStartExecute()
        {
            return ((_currentSequenceViewModel !=null) && !bwTx.IsBusy );
        }
        public ICommand Stop { get { return new CRelatedCommandNoParam(StopExecute, CanStopExecute); } }
        public static void DoEvents()
        {
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Background,
                                                  new Action(delegate { }));
        }
        void StopExecute()
        {
            if (bwTx.IsBusy)
            {
                bwTx.CancelAsync();
                bwTx.ProgressChanged -= bwTx_ProgressChanged;
            }
            while (bwTx.IsBusy)
            {
                DoEvents();
            }
        }
        bool CanStopExecute()
        {
            return bwTx.WorkerSupportsCancellation && bwTx.IsBusy;
        }
        public ICommand Restart { get { return new CRelatedCommandNoParam(RestartExecute, CanRestartExecute); } }
        void RestartExecute()
        {
            StopExecute();
            StartExecute();
        }
        bool CanRestartExecute()
        {
            return true;
        }

        private int iClkStartTime;
        public ICommand ClkStart { get { return new CRelatedCommandNoParam(ClkStartExecute, CanClkStartExecute); } }
        void ClkStartExecute()
        {
            ClkActive = true;
        }
        bool CanClkStartExecute()
        {
            return !ClkActive;
        }

        public ICommand ClkStop { get { return new CRelatedCommandNoParam(ClkStopExecute, CanClkStopExecute); } }
        void ClkStopExecute()
        {
            ClkActive = false;
        }
        bool CanClkStopExecute()
        {
            return ClkActive;
        }

        public ICommand Insert { get { return new CRelatedCommandParam(InsertExecute, CanInsertExecute); } }
        void InsertExecute(object index)
        {
            SolutionCurrentSequence.Steps.Insert((int)index,new CStepViewModel()); 
        }
        bool CanInsertExecute()
        {
            if (SolutionCurrentSequence != null)
            {
                return SolutionCurrentSequence.Steps.Count > 0;
            }
            return false;
        }

        public ICommand Observe { get { return new CRelatedCommandNoParam(ObserveExecute, CanObserveExecute); } }
        private enum WaitResults : int
        {
            WAIT_OBJECT_0 = 0x0,
            WAIT_ABANDONED = 0x80,
            WAIT_TIMEOUT = 0x102,
            INFINITE = 0xFFFF,
            WAIT_FAILED = 0xFFFFFFF
        }
        void ObserveExecute()
        {

            bwRx.WorkerReportsProgress = true;
            bwRx.WorkerSupportsCancellation = true;
            bwRx.DoWork += delegate(object s, DoWorkEventArgs args)
            {
                int time;
                time = 0;
                xlStartCan(ref _iEventHandleRx, ref _iPortHandleRx, ref _ui64TransmitMaskRx);
                while (true)
                {
                    if (bwRx.CancellationPending)
                    {
                        args.Cancel = true;
                        log("Observation stopped");
                        break;
                    }
                    else
                    {
                        XLClass.xl_event xlReceivedEvent = new XLClass.xl_event();
                        XLClass.XLstatus xlStatus = XLClass.XLstatus.XL_SUCCESS;
                        WaitResults lbWaitResult = new WaitResults();
                        lbWaitResult = (WaitResults)WaitForSingleObject(_iEventHandleRx, 1000);
                        if (lbWaitResult != WaitResults.WAIT_TIMEOUT)
                        {
                            xlStatus = XLClass.XLstatus.XL_SUCCESS;
                            while (xlStatus != XLClass.XLstatus.XL_ERR_QUEUE_IS_EMPTY)
                            {
                                xlStatus = _xlDriverRx.XL_Receive(_iPortHandleRx, ref xlReceivedEvent);
                                if (xlStatus == XLClass.XLstatus.XL_SUCCESS)
                                {
                                    if ((xlReceivedEvent.flags & (byte)XLClass.XLeventFlags.XL_EVENT_FLAG_OVERRUN) != 0)
                                    {
                                        //throw new VectorCANcaseXLException("XL_EVENT_FLAG_OVERRUN");
                                    }
                                    if (xlReceivedEvent.tag == (byte)XLClass.XLeventType.XL_RECEIVE_MSG)
                                    {
                                        if ((xlReceivedEvent.tagData.can_Msg.flags & (ushort)XLClass.XLmessageFlags.XL_CAN_MSG_FLAG_OVERRUN) != 0)
                                        {
                                            //throw new VectorCANcaseXLException("XL_CAN_MSG_FLAG_OVERRUN");
                                        }
                                        if ((xlReceivedEvent.tagData.can_Msg.flags & (ushort)XLClass.XLmessageFlags.XL_CAN_MSG_FLAG_ERROR_FRAME) == (ushort)XLClass.XLmessageFlags.XL_CAN_MSG_FLAG_ERROR_FRAME)
                                        {
                                            //throw new VectorCANcaseXLException("ERROR FRAME");
                                        }
                                        else if ((xlReceivedEvent.tagData.can_Msg.flags & (ushort)XLClass.XLmessageFlags.XL_CAN_MSG_FLAG_REMOTE_FRAME) == (ushort)XLClass.XLmessageFlags.XL_CAN_MSG_FLAG_REMOTE_FRAME)
                                        {
                                            //throw new VectorCANcaseXLException("REMOTE FRAME");
                                        }
                                        else if (
                                            ((xlReceivedEvent.tagData.can_Msg.flags & (ushort)XLClass.XLmessageFlags.XL_CAN_MSG_FLAG_NERR) == 0) &&
                                            ((xlReceivedEvent.tagData.can_Msg.flags & (ushort)XLClass.XLmessageFlags.XL_CAN_MSG_FLAG_TX_COMPLETED) == 0) &&
                                            ((xlReceivedEvent.tagData.can_Msg.flags & (ushort)XLClass.XLmessageFlags.XL_CAN_MSG_FLAG_TX_REQUEST) == 0)
                                            )
                                        {
                                            foreach (CMessageViewModel msg in SolutionCurrentProject.Messages)
                                            {
                                                if (msg.MessageId == xlReceivedEvent.tagData.can_Msg.id)
                                                    msg.MessageData = xlReceivedEvent.tagData.can_Msg.data;
                                            } 
                                        }
                                    }
                                }
                            }
                        }
                        bwRx.ReportProgress(1, ++time);
                    }
                    Thread.Sleep(1);
                }
            };
            bwRx.ProgressChanged += delegate(object s, ProgressChangedEventArgs args)
            {
                SolutionCurrentObservationTime = (int)args.UserState;
                //SolutionCurrentProject.RaisePropertyChanged("Messages");
                
            };
            bwRx.RunWorkerAsync();
        }
        bool CanObserveExecute()
        {
            return !bwRx.IsBusy;
        }
        public ICommand ObserveStop { get { return new CRelatedCommandNoParam(ObserveStopExecute, CanObserveStopExecute); } }
        void ObserveStopExecute()
        {
            bwRx.CancelAsync();
        }
        bool CanObserveStopExecute()
        {
            return bwRx.WorkerSupportsCancellation && bwRx.IsBusy;
        }

        public ICommand SendMessage { get { return new CRelatedCommandParam(SendMflMessageExecute, CanSendMflMessageExecute); } }
        void SendMflMessageExecute(object IdDlcStartBitLengthValueInterval)
        {
             string[] parameters = ((String)IdDlcStartBitLengthValueInterval).Split('_') ; 

             UInt16 id = Convert.ToUInt16(parameters[0]);
             UInt16 dlc = Convert.ToUInt16(parameters[1]);
             UInt16 length = Convert.ToUInt16(parameters[2]);
             int startBit =  Convert.ToUInt16(parameters[3]);
             int value = Convert.ToInt32(parameters[4]);
             int interval = Convert.ToInt32(parameters[5]);
             
             int _iEventHandleLocal = -1;
             int _iPortHandleLocal = -1;
             UInt64 _ui64TransmitMaskLocal = 0;
             xlStartCan(ref _iEventHandleLocal, ref _iPortHandleLocal, ref _ui64TransmitMaskLocal);
             //XLClass.xl_can_message xlMsg = new XLClass.xl_can_message();
             XLClass.xl_event_collection xlEventCollection = new XLClass.xl_event_collection(0);
             XLClass.xl_event xlEvent;
             xlEventCollection.xlEvent.Clear();
             xlEvent = new XLClass.xl_event();
             xlEvent.tagData.can_Msg.id = id;
             xlEvent.tagData.can_Msg.dlc = dlc;
             xlEvent.tagData.can_Msg.data = getMessageValue(new byte[dlc], value, startBit, length);
             xlEvent.tag = (byte)XLClass.XLeventType.XL_TRANSMIT_MSG;
             xlEventCollection.xlEvent.Add(xlEvent);
             xlEventCollection.messageCount = (uint)xlEventCollection.xlEvent.Count;

             for (int idx = 0; idx < interval; idx++)
             {
                 _xlDriverTx.XL_CanTransmit(_iPortHandleLocal, /* _ui64TransmitMaskLocal*/1, xlEventCollection);
                 Thread.Sleep(1);
             }
             xlEventCollection.xlEvent.Clear();
             xlEvent.tagData.can_Msg.data = xlEvent.tagData.can_Msg.data = getMessageValue(new byte[dlc], 0, startBit, length);
             xlEventCollection.xlEvent.Add(xlEvent);
             _xlDriverTx.XL_CanTransmit(_iPortHandleLocal,  /* _ui64TransmitMaskLocal*/ 1, xlEventCollection);

             _xlDriverTx.XL_ClosePort(_iPortHandleLocal);
             _xlDriverTx.XL_CloseDriver();
        }
        bool CanSendMflMessageExecute()
        {
            return true;
        }

        public ICommand AddProject { get { return new CRelatedCommandParam(AddProjectExecute, CanAddProjectExecute); } }
        void AddProjectExecute(object name)
        {
            if (!String.IsNullOrEmpty((String)name))
            {
               Projects.Add(new CProjectViewModel { ProjectName = (String)name });
            }
            else
            {
                MessageBox.Show("Add the name of project to the textbox next to the button");
            }
        }
        bool CanAddProjectExecute()
        {
            return true;
        }
        public ICommand LoadSolution { get { return new CRelatedCommandNoParam(LoadSolutionExecute, CanLoadSolutionExecute); } }
        void LoadSolutionExecute()
        {
            try
            {
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.DefaultExt = ".gun";
                dlg.Filter = "GUN Files (*.gun)|*.gun"; 
                if (dlg.ShowDialog() == true)
                {
                    String sPath = string.Empty;
                    sPath = dlg.FileName;
                    CProject ieProject = new CProject();
                    BinaryFormatter bfProjekt = new BinaryFormatter();
                    FileStream fsProject = new FileStream((String)sPath, FileMode.Open);
                    Projects = (ObservableCollection<CProjectViewModel>)bfProjekt.Deserialize(fsProject);
                    RaisePropertyChanged("Projects");
                    fsProject.Close();
                    log(string.Format("Solution {0} loaded.", (String)sPath));
                    Path = sPath;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        bool CanLoadSolutionExecute()
        {
            return true;
        }
        public ICommand SaveSolution { get { return new CRelatedCommandParam(SaveSolutionExecute, SaveSolutionExecute); } }
        void SaveSolutionExecute(object path)
        {
            try
            {
                if (File.Exists((String)path))
                {
                    if (MessageBox.Show(string.Format("Replace file: {0} ?", (String)path), "Save Soution", MessageBoxButton.YesNoCancel, MessageBoxImage.Question) != MessageBoxResult.Yes)
                    {
                        return;
                    }
                }
                BinaryFormatter bfProjekt = new BinaryFormatter();
                FileStream fsProject = new FileStream((String)path, FileMode.Create);
                bfProjekt.Serialize(fsProject, _projects);
                fsProject.Close();
                log(string.Format("Solution {0} saved.", (String)path));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        bool SaveSolutionExecute()
        {
            return true;
        }
        public ICommand LoadRecentSolution { get { return new CRelatedCommandParam(LoadRecentSolutionExecute, LoadRecentSolutionExecute); } }
        void LoadRecentSolutionExecute(object path)
        {
            try
            {
                if (File.Exists((String)path))
                {
                    String sPath = (String)path;
                    CProject ieProject = new CProject();
                    BinaryFormatter bfProjekt = new BinaryFormatter();
                    FileStream fsProject = new FileStream((String)sPath, FileMode.Open);
                    Projects = (ObservableCollection<CProjectViewModel>)bfProjekt.Deserialize(fsProject);
                    RaisePropertyChanged("Projects");
                    fsProject.Close();
                    log(string.Format("Solution {0} loaded.", (String)sPath));
                    Path = sPath;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        bool LoadRecentSolutionExecute()
        {
            return true;
        }

        [field: NonSerialized] public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

[Serializable]public class CSignal : INotifyPropertyChanged
    {
        private string _name;
        private int _length;
        private int _startBit;
        private string _intel;
        private string _signed;
        private int _value;
        private string _comment;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Lenght
        {
            get { return _length; }
            set { _length = value; }
        }
        public int StartBit
        {
            get { return _startBit; }
            set { _startBit = value; }
        }
        public string Intel
        {
            get { return _intel; }
            set { _intel = value; }
        }
        public string Signed
        {
            get { return _signed; }
            set { _signed = value; }
        }
        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }
        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }

        [field: NonSerialized] public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
[Serializable]public class CSignalViewModel : INotifyPropertyChanged
    {
        private CSignal _signal;
        public CSignal Signal
        {
            get { return _signal; }
            set { _signal = value; }
        }
        public CSignalViewModel()
        {
            _signal = new CSignal();
        }
        public string SignalName
        {
            get { return _signal.Name; }
            set { _signal.Name = value; }
        }
        public int SignalLenght
        {
            get { return _signal.Lenght; }
            set { _signal.Lenght = value; }
        }
        public int SignalStartBit
        {
            get { return _signal.StartBit; }
            set { _signal.StartBit = value; }
        }
        public string SignalIntel
        {
            get { return _signal.Intel; }
            set { _signal.Intel = value; }
        }
        public string SignalSigned
        {
            get { return _signal.Signed; }
            set { _signal.Signed = value; }
        }
        public int SignalValue
        {
            get { return _signal.Value; }
            set 
            { 
                _signal.Value = value;
                RaisePropertyChanged("SignalValue");
            }
        }
        public string SignalComment
        {
            get { return _signal.Comment; }
            set { _signal.Comment = value; }
        }

        [field: NonSerialized] public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

[Serializable]public class CMessage : INotifyPropertyChanged
    {
        private string _name;
        private int _id;
        private int _dlc;
        private string _ecu;
        private byte[] _data;
        private string _comment;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public int Dlc
        {
            get { return _dlc; }
            set { _dlc = value; }
        }
        public string Ecu
        {
            get { return _ecu; }
            set { _ecu = value; }
        }
        public byte[] Data
        {
            get { return _data; }
            set 
            { 
                _data = value;
                RaisePropertyChanged("Data");
            }
        }
        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }

        [field: NonSerialized] public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
[Serializable]public class CMessageViewModel : INotifyPropertyChanged
    {
        private CMessage _message;
        ObservableCollection<CSignalViewModel> _signals = new ObservableCollection<CSignalViewModel>();
        public ObservableCollection<CSignalViewModel> Signals
        {
            get { return _signals; }
            set { _signals = value; }
        }
        public CMessage Message
        {
            get { return _message; }
            set { _message = value; }
        }
        public CMessageViewModel()
        {
            _message = new CMessage(){ Id=1, Name ="Message", Dlc = 8, Ecu ="Ecu", Data=new Byte[]{0,1,2,3,4,5,6,7}};
        }
        public int MessageId 
        {
            get { return _message.Id ; }
            set { _message.Id = value; }
        }
        public string MessageName 
        {
            get { return _message.Name; }
            set { _message.Name = value; }
        }
        public int MessageDlc
        {
            get { return _message.Dlc; }
            set { _message.Dlc = value; }
        }
        public string MessageEcu
        {
            get { return _message.Ecu; }
            set { _message.Ecu = value; }
        }
        public byte[] MessageData
        {
            get { return _message.Data; }
            set 
            { 
                _message.Data = value;
                foreach(CSignalViewModel sig in Signals)
                {
                    sig.SignalValue = (int) getSignalValue(_message.Data, sig.SignalStartBit, sig.SignalLenght);
                }
                RaisePropertyChanged("MessageData");
            }
        }
        public string MessageComment
        {
            get { return _message.Comment; }
            set { _message.Comment = value; }
        }
        private UInt64 getSignalValue(byte[] byteMessage, int iStartBit, int iLength)
        {
            BitArray bitsMessage = new BitArray(byteMessage);
            UInt64 ui64SignalValue = 0;
            int iSignalPow = 0;

            bool[] bitsMsg = new bool[64];
            bool[] bitsSgl = new bool[iLength];
            uint[] uiValue = new uint[1];

            bitsMessage.CopyTo(bitsMsg, 0);

            for (int idx = iStartBit; idx < (iStartBit + iLength); idx++)
            {
                bitsSgl[iSignalPow] = bitsMsg[idx];
                if (bitsMsg[idx])
                {
                    ui64SignalValue = ui64SignalValue + Convert.ToUInt64(Math.Pow(2, iSignalPow));
                }
                iSignalPow++;
            }

            return ui64SignalValue;
        }
    
        [field: NonSerialized] public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
[Serializable]public class CSendetMessageViewModel : INotifyPropertyChanged
{
    private int _startTime=0;
    private int _stopTime=0;
    private CMessageViewModel _message;
    private CSignalViewModel _signal;
    public int StartTime
    {
        get { return _startTime; }
        set { _startTime = value; }
    }
    public int StopTime
    {
        get { return _stopTime; }
        set { _stopTime = value; }
    }
    public CMessageViewModel Message
    {
        get { return _message; }
        set { _message = value; }
    }
    public CSignalViewModel Signal
    {
        get { return _signal; }
        set { _signal = value; }
    }

    public CSendetMessageViewModel(CMessageViewModel message, int start, int stop)
    {
        _message = new CMessageViewModel() { MessageName = message.MessageName, MessageId = message.MessageId , MessageData = message.MessageData, MessageDlc = message.MessageDlc  };
        _startTime  = start;
        _stopTime = stop;
    }

    public CSendetMessageViewModel(CStepViewModel step)
    {
        _message = step.StepMessage;
        _signal = step.StepSignal;
    }
    [field: NonSerialized]
    public event PropertyChangedEventHandler PropertyChanged;
    private void RaisePropertyChanged(string propertyName)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null)
        {
            handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

[Serializable]public class CSequence : INotifyPropertyChanged
    {
        private string _name;
        private string _comment;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }

        [field: NonSerialized] public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
[Serializable]public class CSequenceViewModel : INotifyPropertyChanged
    {
        private CSequence _sequence;
        ObservableCollection<CStepViewModel> _steps = new ObservableCollection<CStepViewModel>();
        public ObservableCollection<CStepViewModel> Steps
        {
            get { return _steps; }
            set { _steps = value; }
        }
        public CSequence Sequence
        {
            get { return _sequence; }
            set { _sequence = value; }
        }
        public string SequenceName
        {
            get { return _sequence.Name ; }
            set { _sequence.Name =value; }
        }
        public string SequenceComment
        {
            get { return _sequence.Comment; }
            set { _sequence.Comment = value; }
        }

        public CSequenceViewModel()
        {
            _sequence=new CSequence();
        }
        public ICommand AddStep { get { return new CRelatedCommandNoParam(AddStepExecute, CanAddStepExecute); } }
        void AddStepExecute()
        {
            _steps.Add(new CStepViewModel());
        }
        bool CanAddStepExecute()
        {
            return true;
        }

        [field: NonSerialized] public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

[Serializable]public class CStep : INotifyPropertyChanged 
    {
        private string _command;
        private CMessageViewModel  _message;
        private CSignalViewModel _signal;

        private int _time;
        private int _value;
        public string Command
        {
            get { return _command; }
            set { _command = value; }
        }
        public CMessageViewModel Message
        {
            get { return _message; }
            set 
            { 
                _message = value;
            }
        }
        public CSignalViewModel Signal
        {
            get { return _signal;}
            set { _signal = value; }
        }
        public int Time
        {
            get { return _time; }
            set { _time = value; }
        }
        public int Value 
        {
            get { return _value; }
            set { _value = value; }
        }

        [field: NonSerialized] public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
[Serializable]public class CStepViewModel : INotifyPropertyChanged
    {
        CStep _step = new CStep();
        ObservableCollection<CSignalViewModel> _signals = new ObservableCollection<CSignalViewModel>();
        public string StepCommand
        {
            get { return _step.Command ; }
            set { _step.Command = value; }
        }
        public CMessageViewModel StepMessage
        {
            get { return _step.Message; }
            set 
            { 
                _step.Message = value;
                _signals = _step.Message.Signals;
                RaisePropertyChanged("StepSignals");
            }
        }
        public ObservableCollection<CSignalViewModel> StepSignals
        {
            get { return _signals; }
            set { _signals = value; }
        }
        public CSignalViewModel StepSignal
        {
            get { return _step.Signal; }
            set 
            {
                _step.Signal = value;
            }
        }
        public int StepTime
        {
            get { return _step.Time; }
            set { _step.Time = value; }
        }
        public int StepValue
        {
            get { return _step.Value; }
            set { _step.Value = value; }
        }

        [field: NonSerialized] public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

[Serializable]public class AsyncObservableCollection<T> : ObservableCollection<T>
{
    [field: NonSerialized]
    private SynchronizationContext _synchronizationContext = SynchronizationContext.Current;

    public AsyncObservableCollection()
    {
    }

    public AsyncObservableCollection(IEnumerable<T> list)
        : base(list)
    {
    }

    protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
    {
        if (SynchronizationContext.Current == _synchronizationContext)
        {
            // Execute the CollectionChanged event on the current thread
            RaiseCollectionChanged(e);
        }
        else
        {
            // Post the CollectionChanged event on the creator thread
            _synchronizationContext.Post(RaiseCollectionChanged, e);
        }
    }

    private void RaiseCollectionChanged(object param)
    {
        // We are in the creator thread, call the base implementation directly
        base.OnCollectionChanged((NotifyCollectionChangedEventArgs)param);
    }

    protected override void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        if (_synchronizationContext == null) _synchronizationContext = SynchronizationContext.Current;

        if (SynchronizationContext.Current == _synchronizationContext)
        {
            // Execute the PropertyChanged event on the current thread
            RaisePropertyChanged(e);
        }
        else
        {
            // Post the PropertyChanged event on the creator thread
            _synchronizationContext.Post(RaisePropertyChanged, e);
        }
    }

    private void RaisePropertyChanged(object param)
    {
        // We are in the creator thread, call the base implementation directly
        base.OnPropertyChanged((PropertyChangedEventArgs)param);
    }
}

}
