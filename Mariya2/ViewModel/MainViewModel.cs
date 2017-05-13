using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;

namespace Mariya2
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<ZamerList> KolichestvoZamerov { get; set; }
        public ObservableCollection<ZamerList> SpisokZamerov { get; set; }
        public ObservableCollection<CityModel> CityList { get; set; }

        public string ClientName { get; set; }
        public string ClientPhone { get; set; }
        public int OstalosZamerov { get; set; }
        public string OshibkaGorod { get; set; }
        public string OshibkaPhone { get; set; }
        public string OshibkaClientName { get; set; }
        public string OshibkaDate { get; set; }
        public string OshibkaNetZamershikov { get; set; }



        private int _dateDay = 01;
        private int _dateMounth = 01;
        private int _dateYear = 2017;
        public int DateDay
        {
            get { return _dateDay; }
            set
            {
                if (_dateDay != value)
                {
                    if (value > 0 & value < 32)
                    {
                        _dateDay = value;
                    }
                    else
                    {
                        DateDay = _dateDay;
                        RaisePropertyChanged(() => DateDay);
                    }
                }
            }
        }
        public int DateMounth
        {
            get { return _dateMounth; }
            set
            {
                if (_dateMounth != value)
                {
                    if (value > 0 & value < 13)
                    {
                        _dateMounth = value;
                    }
                    else
                    {
                        DateDay = _dateMounth;
                        RaisePropertyChanged(() => DateMounth);
                    }
                }
            }
        }
        public int DateYear
        {
            get { return _dateYear; }
            set
            {
                if (_dateYear != value)
                {
                    if (value >= 2000 & value <= 2020)
                    {
                        _dateYear = value;
                    }
                    else
                    {
                        DateDay = _dateYear;
                        RaisePropertyChanged(() => DateYear);
                    }
                }
            }
        }


        private CityModel _cityName;
        public CityModel CityName
        {
            get { return _cityName; }
            set
            {
                if (_cityName != value)
                {
                    OshibkaGorod = "";
                    RaisePropertyChanged(() => OshibkaGorod);
                    _cityName = value;
                }
            }
        }

        public MainViewModel()
        {
            SpisokZamerov = new ObservableCollection<ZamerList>();
            KolichestvoZamerov = new ObservableCollection<ZamerList>();
            CityList = new ObservableCollection<CityModel>();
            CreateModelList();
            ZapolnenieZamerList();
            ZapolnenieKolichestvaZamerov();


        }

        private ICommand _zdelatZapis;
        public ICommand ZdelatZapis
        {
            get { return _zdelatZapis ?? (_zdelatZapis = new RelayCommand(AddClient)); }
        }


        private bool CanAddClient()
        {
            int r = CityList.IndexOf(CityName);
            if (r >= 0)
            {
                if (CityList[r].DateOfZamer[DateDay-1, DateMounth-1, DateYear - 2000].CountOfZamer > CityList[r].DateOfZamer[DateDay - 1, DateMounth - 1, DateYear - 2000].ClientList.Count)
                {
                    OshibkaNetZamershikov = "";
                    RaisePropertyChanged(() => OshibkaNetZamershikov);
                    return true;
                }
                else
                {
                    OshibkaNetZamershikov = "На этот день нет замеров";
                    RaisePropertyChanged(() => OshibkaNetZamershikov);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public void AddClient()
        {
            bool oshibka = false;
            if (CityName == null)
            {
                oshibka = true;
                OshibkaGorod = "Выберете город!";
                RaisePropertyChanged(() => OshibkaGorod);
            }
            if ((ClientName == null) || (ClientName == ""))
            {
                oshibka = true;
                OshibkaClientName = "Введите Ф.И.О.";
                RaisePropertyChanged(() => OshibkaClientName);
            }
            else
            {
                OshibkaClientName = "";
                RaisePropertyChanged(() => OshibkaClientName);
            }
            if ((ClientPhone == null) || (ClientPhone == ""))
            {
                oshibka = true;
                OshibkaPhone = "Введите телефон";
                RaisePropertyChanged(() => OshibkaPhone);
            }
            else
            {
                OshibkaPhone = "";
                RaisePropertyChanged(() => OshibkaPhone);
            }
            if (DateDay < 1 || DateDay > 31 || DateMounth < 1 || DateMounth > 12 || DateYear < 2000 || DateYear > 2020)
            {
                oshibka = true;
                OshibkaDate = "Введите дату";
                RaisePropertyChanged(() => OshibkaDate);
            }
            else
            {
                OshibkaDate = "";
                RaisePropertyChanged(() => OshibkaDate);
            }

            if (!oshibka & CanAddClient())
            {
                SpisokZamerov.Add(new ZamerList(_cityName.CityName, ClientName, ClientPhone, DateDay, DateMounth, DateYear));
                int r = CityList.IndexOf(CityName);
                CityList[r].DateOfZamer[DateDay-1, DateMounth -1, DateYear -2000].ClientList.Add(new Client(ClientName, ClientPhone));
                ZapolnenieKolichestvaZamerov();

            }

        }
        private void ZapolnenieKolichestvaZamerov()
        {
            KolichestvoZamerov.Clear();
            for (int z = 0; z < 19; z++)
            {
                for (int y = 0; y < 12; y++)
                {
                    for (int x = 0; x < 30; x++)
                    {
                        foreach (CityModel city in CityList)
                        {
                            OstalosZamerov = city.DateOfZamer[x, y, z].CountOfZamer - city.DateOfZamer[x, y, z].ClientList.Count;
                            KolichestvoZamerov.Add(new ZamerList(city.CityName, city.DateOfZamer[x, y, z].CountOfZamer, OstalosZamerov, x + 1, y + 1, z + 2000));
                        }
                    }
                }
            }
        }

        private void ZapolnenieZamerList()
        {
            for (int z = 0; z < 19; z++)
            {
                for (int y = 0; y < 12; y++)
                {
                    for (int x = 0; x < 30; x++)
                    {
                        foreach (CityModel city in CityList)
                        {
                            if (city.DateOfZamer[x, y, z].ClientList.Count != 0)
                            {
                                foreach (Client client in city.DateOfZamer[x, y, z].ClientList)
                                {
                                    SpisokZamerov.Add(new ZamerList(city.CityName, client.ClientName, client.ClientPhone, x + 1, y + 1, z + 2000));
                                }
                            }
                        }
                    }
                }
            }
        }

        public void AddCity(string cityName)
        {
            CityList.Add(new CityModel(cityName));
        }

        public void CreateModelList()
        {
            AddCity("Москва");
            AddCity("Саратов");
            AddCity("Самара");
            CityList[0].DateOfZamer[21, 4, 17].CountOfZamer = 6;
            CityList[1].DateOfZamer[21, 4, 17].ClientList.Add(new Client("Иванов И.И.", "89427654213"));
            CityList[2].DateOfZamer[21, 4, 17].ClientList.Add(new Client("Петров П.П.", "89427652813"));
            CityList[1].DateOfZamer[21, 4, 17].ClientList.Add(new Client("Сидоро А.И.", "89427654213"));
            CityList[2].DateOfZamer[21, 4, 17].ClientList.Add(new Client("Жернов О.В.", "89442352813"));
            CityList[0].DateOfZamer[21, 4, 17].ClientList.Add(new Client("Титов М.С.", "89427655323"));
            CityList[1].DateOfZamer[21, 4, 17].ClientList.Add(new Client("Сергеев С.П.", "89428762813"));
            CityList[2].DateOfZamer[22, 4, 17].CountOfZamer = 8;
            CityList[2].DateOfZamer[22, 4, 17].ClientList.Add(new Client("Иванов И.И.", "89427654213"));
            CityList[1].DateOfZamer[22, 4, 17].ClientList.Add(new Client("Петров П.П.", "89427652813"));
            CityList[0].DateOfZamer[22, 4, 17].ClientList.Add(new Client("Сидоро А.И.", "89427654213"));
            CityList[1].DateOfZamer[22, 4, 17].ClientList.Add(new Client("Жернов О.В.", "89442352813"));
            CityList[0].DateOfZamer[22, 4, 17].ClientList.Add(new Client("Титов М.С.", "89427655323"));
            CityList[1].DateOfZamer[22, 4, 17].ClientList.Add(new Client("Сергеев С.П.", "89428762813"));
        }
    }
}
