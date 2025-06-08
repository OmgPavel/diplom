namespace AvtoMobil
{
    public interface IApp
    {
        static abstract ObservableCollection<App.BMWmobil> bmwcollection { get; set; }
        static abstract ObservableCollection<App.FCAmobil> FCAcollection { get; set; }
        static abstract ObservableCollection<App.Fordmobil> fordcollection { get; set; }
        static abstract ObservableCollection<App.Generalmotorsmobil> generalmotorscollection { get; set; }
        static abstract ObservableCollection<App.GrouopPSAmobil> grouopPSAcollection { get; set; }
        static abstract ObservableCollection<App.Hondamobil> hondacollection { get; set; }
        static abstract ObservableCollection<App.Hyndaikiamobil> hyndaikiacollection { get; set; }
        static abstract ObservableCollection<App.MercedesBenzmobil> mercedesbenzcollection { get; set; }
        static abstract ObservableCollection<App.Proizvoditely> proizvoditelycollection { get; set; }
        static abstract ObservableCollection<App.RenaultNissanMistsubishimodil> renaultnissanmitsubishicollection { get; set; }
        static abstract ObservableCollection<App.Suzukimobil> suzukicollection { get; set; }
        static abstract ObservableCollection<App.Toyotamodbil> toyotacollection { get; set; }
        static abstract ObservableCollection<App.Vagmobil> vagcollection { get; set; }
    }
}