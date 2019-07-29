using AppliMeteo.DAL;
using AppliMeteo.Helper;
using AppliMeteo.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppliMeteo.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        MeteoRoot mr;
        string city = "Boncelles";
        private readonly IDialogService _dialogService;

        #region -- Propriétés --

        private string ville;

        public string Ville
        {
            get { return ville; }
            set
            {
                ville = value;
                RaisePropertyChanged(() => Ville);
            }
        }

        private string date;

        public string Date
        {
            get { return date; }
            set
            {
                date = value;
                RaisePropertyChanged(() => Date);
            }
        }

        private string conditionImg;

        public string ConditionImg
        {
            get { return conditionImg; }
            set
            {
                conditionImg = value;
                RaisePropertyChanged(() => ConditionImg);
            }
        }

        private string condition;

        public string Condition
        {
            get { return condition; }
            set
            {
                condition = value;
                RaisePropertyChanged(() => Condition);
            }
        }

        private string temp;

        public string Temp
        {
            get { return temp; }
            set
            {
                temp = value;
                RaisePropertyChanged(() => Temp);
            }
        }

        private string humidite;

        public string Humidite
        {
            get { return humidite; }
            set
            {
                humidite = value;
                RaisePropertyChanged(() => Humidite);
            }
        }

        private string imgHuit;

        public string ImgHuit
        {
            get { return imgHuit; }
            set
            {
                imgHuit = value;
                RaisePropertyChanged(() => ImgHuit);
            }
        }

        private string imgdouze;

        public string ImgDouze
        {
            get { return imgdouze; }
            set
            {
                imgdouze = value;
                RaisePropertyChanged(() => ImgDouze);
            }
        }

        private string imgSeize;

        public string ImgSeize
        {
            get { return imgSeize; }
            set
            {
                imgSeize = value;
                RaisePropertyChanged(() => ImgSeize);
            }
        }

        private string imgVingt;

        public string ImgVingt
        {
            get { return imgVingt; }
            set
            {
                imgVingt = value;
                RaisePropertyChanged(() => ImgVingt);
            }
        }

        private string imgVingtTrois;

        public string ImgVingtTrois
        {
            get { return imgVingtTrois; }
            set
            {
                imgVingtTrois = value;
                RaisePropertyChanged(() => ImgVingtTrois);
            }
        }

        private string tempHuit;

        public string TempHuit
        {
            get { return tempHuit; }
            set
            {
                tempHuit = value;
                RaisePropertyChanged(() => TempHuit);
            }
        }

        private string tempDouze;

        public string TempDouze
        {
            get { return tempDouze; }
            set
            {
                tempDouze = value;
                RaisePropertyChanged(() => TempDouze);
            }
        }

        private string tempSeize;

        public string TempSeize
        {
            get { return tempSeize; }
            set
            {
                tempSeize = value;
                RaisePropertyChanged(() => TempSeize);
            }
        }

        private string tempVingt;

        public string TempVingt
        {
            get { return tempVingt; }
            set
            {
                tempVingt = value;
                RaisePropertyChanged(() => TempVingt);
            }
        }

        private string tempVingtTrois;

        public string TempVingtTrois
        {
            get { return tempVingtTrois; }
            set
            {
                tempVingtTrois = value;
                RaisePropertyChanged(() => TempVingtTrois);
            }
        }

        private string humiditeHuit;

        public string HumiditeHuit
        {
            get { return humiditeHuit; }
            set
            {
                humiditeHuit = value;
                RaisePropertyChanged(() => HumiditeHuit);
            }
        }

        private string humiditeDouze;

        public string HumiditeDouze
        {
            get { return humiditeDouze; }
            set
            {
                humiditeDouze = value;
                RaisePropertyChanged(() => HumiditeDouze);
            }
        }

        private string humiditeSeize;

        public string HumiditeSeize
        {
            get { return humiditeSeize; }
            set
            {
                humiditeSeize = value;
                RaisePropertyChanged(() => HumiditeSeize);
            }
        }

        private string humiditeVingt;

        public string HumiditeVingt
        {
            get { return humiditeVingt; }
            set
            {
                humiditeVingt = value;
                RaisePropertyChanged(() => HumiditeVingt);
            }
        }

        private string humiditeVingtTrois;

        public string HumiditeVingtTrois
        {
            get { return humiditeVingtTrois; }
            set
            {
                humiditeVingtTrois = value;
                RaisePropertyChanged(() => HumiditeVingtTrois);
            }
        }

        private string jour1;

        public string Jour1
        {
            get { return jour1; }
            set
            {
                jour1 = value;
                RaisePropertyChanged(() => Jour1);
            }
        }

        private string jour2;

        public string Jour2
        {
            get { return jour2; }
            set
            {
                jour2 = value;
                RaisePropertyChanged(() => Jour2);
            }
        }

        private string jour3;

        public string Jour3
        {
            get { return jour3; }
            set
            {
                jour3 = value;
                RaisePropertyChanged(() => Jour3);
            }
        }

        private string jour4;

        public string Jour4
        {
            get { return jour4; }
            set
            {
                jour4 = value;
                RaisePropertyChanged(() => Jour4);
            }
        }

        private string imgJour0;

        public string ImgJour0
        {
            get { return imgJour0; }
            set
            {
                imgJour0 = value;
                RaisePropertyChanged(() => ImgJour0);
            }
        }

        private string imgJour1;

        public string ImgJour1
        {
            get { return imgJour1; }
            set
            {
                imgJour1 = value;
                RaisePropertyChanged(() => ImgJour1);
            }
        }

        private string imgJour2;

        public string ImgJour2
        {
            get { return imgJour2; }
            set
            {
                imgJour2 = value;
                RaisePropertyChanged(() => ImgJour2);
            }
        }

        private string imgJour3;

        public string ImgJour3
        {
            get { return imgJour3; }
            set
            {
                imgJour3 = value;
                RaisePropertyChanged(() => ImgJour3);
            }
        }

        private string imgJour4;

        public string ImgJour4
        {
            get { return imgJour4; }
            set
            {
                imgJour4 = value;
                RaisePropertyChanged(() => ImgJour4);
            }
        }

        private string jour0TempMax;

        public string Jour0TempMax
        {
            get { return jour0TempMax; }
            set
            {
                jour0TempMax = value;
                RaisePropertyChanged(() => Jour0TempMax);
            }
        }

        private string jour0TempMin;

        public string Jour0TempMin
        {
            get { return jour0TempMin; }
            set
            {
                jour0TempMin = value;
                RaisePropertyChanged(() => Jour0TempMin);
            }
        }

        private string jour1TempMax;

        public string Jour1TempMax
        {
            get { return jour1TempMax; }
            set
            {
                jour1TempMax = value;
                RaisePropertyChanged(() => Jour1TempMax);
            }
        }

        private string jour1TempMin;

        public string Jour1TempMin
        {
            get { return jour1TempMin; }
            set
            {
                jour1TempMin = value;
                RaisePropertyChanged(() => Jour1TempMin);
            }
        }

        private string jour2TempMax;

        public string Jour2TempMax
        {
            get { return jour2TempMax; }
            set
            {
                jour2TempMax = value;
                RaisePropertyChanged(() => Jour2TempMax);
            }
        }

        private string jour2TempMin;

        public string Jour2TempMin
        {
            get { return jour2TempMin; }
            set
            {
                jour2TempMin = value;
                RaisePropertyChanged(() => Jour2TempMin);
            }
        }

        private string jour3TempMax;

        public string Jour3TempMax
        {
            get { return jour3TempMax; }
            set
            {
                jour3TempMax = value;
                RaisePropertyChanged(() => Jour3TempMax);
            }
        }

        private string jour3TempMin;

        public string Jour3TempMin
        {
            get { return jour3TempMin; }
            set
            {
                jour3TempMin = value;
                RaisePropertyChanged(() => Jour3TempMin);
            }
        }

        private string jour4TempMax;

        public string Jour4TempMax
        {
            get { return jour4TempMax; }
            set
            {
                jour4TempMax = value;
                RaisePropertyChanged(() => Jour4TempMax);
            }
        }

        private string jour4TempMin;

        public string Jour4TempMin
        {
            get { return jour4TempMin; }
            set
            {
                jour4TempMin = value;
                RaisePropertyChanged(() => Jour4TempMin);
            }
        }

        #endregion

        #region -- Command --
        public RelayCommand<string> Search { get; set; }
        public RelayCommand btnRefresh { get; set; }
        public RelayCommand btnSweater { get; set; }
        #endregion

        public MainViewModel(IDialogService dialog)
        {
            Search = new RelayCommand<string>(SearchAction, SearchCanExecute);
            btnRefresh = new RelayCommand(RefreshAction);
            btnSweater = new RelayCommand(SweaterAction);
            _dialogService = dialog;
            if(CrossConnectivity.Current.IsConnected)
                Chargement(city);
        }

        private bool SearchCanExecute(string t)
        {
            return true;
        }

        private async void SearchAction(string t)
        {
            if (!string.IsNullOrWhiteSpace(t) && CrossConnectivity.Current.IsConnected)
            {
                using (var repo = new Connector(false))
                {
                    if (await repo.IsCityExisting(t))
                    {
                        Chargement(t);
                        city = t;
                    }
                    else
                    {
                        await _dialogService.ShowMessage($"La ville  '{t}' n'existe pas !", "Erreur");
                    }
                }
            }
        }

        private void SweaterAction()
        {
            App.Locator.NavigationService.NavigateTo(PageName.SecondPage.ToString());
        }

        private void RefreshAction()
        {
            if(CrossConnectivity.Current.IsConnected)
                Chargement(city);
        }

        private async void Chargement(string t)
        {
            using (var repo = new Connector(true)){}

            using (var repo = new APIRecuperator())
            {
                mr = await repo.GetMeteoAsync(t);
                Ville = mr.city_info.name;
                Date = $"{mr.current_condition.date} - {mr.current_condition.hour}";
                Temp = $"{mr.current_condition.tmp}°C";
                Humidite = $"{mr.current_condition.humidity}%";
                Condition = mr.current_condition.condition;
                ConditionImg = mr.current_condition.icon_big;
                ImgHuit = mr.fcst_day_0.hourly_data._8H00.ICON;
                ImgDouze = mr.fcst_day_0.hourly_data._12H00.ICON;
                ImgSeize = mr.fcst_day_0.hourly_data._16H00.ICON;
                ImgVingt = mr.fcst_day_0.hourly_data._20H00.ICON;
                ImgVingtTrois = mr.fcst_day_0.hourly_data._23H00.ICON;
                TempHuit = $"{mr.fcst_day_0.hourly_data._8H00.TMP2m}°";
                TempDouze = $"{mr.fcst_day_0.hourly_data._12H00.TMP2m}°";
                TempSeize = $"{mr.fcst_day_0.hourly_data._16H00.TMP2m}°";
                TempVingt = $"{mr.fcst_day_0.hourly_data._20H00.TMP2m}°";
                TempVingtTrois = $"{mr.fcst_day_0.hourly_data._23H00.TMP2m}°";
                HumiditeHuit = $"{mr.fcst_day_0.hourly_data._8H00.RH2m}%";
                HumiditeDouze = $"{mr.fcst_day_0.hourly_data._12H00.RH2m}%";
                HumiditeSeize = $"{mr.fcst_day_0.hourly_data._16H00.RH2m}%";
                HumiditeVingt = $"{mr.fcst_day_0.hourly_data._20H00.RH2m}%";
                HumiditeVingtTrois = $"{mr.fcst_day_0.hourly_data._23H00.RH2m}%";
                Jour1 = mr.fcst_day_1.day_short;
                Jour2 = mr.fcst_day_2.day_short;
                Jour3 = mr.fcst_day_3.day_short;
                Jour4 = mr.fcst_day_4.day_short;
                ImgJour0 = mr.fcst_day_0.icon;
                ImgJour1 = mr.fcst_day_1.icon;
                ImgJour2 = mr.fcst_day_2.icon;
                ImgJour3 = mr.fcst_day_3.icon;
                ImgJour4 = mr.fcst_day_4.icon;
                Jour0TempMax = $"{mr.fcst_day_0.tmax}°";
                Jour0TempMin = $"{mr.fcst_day_0.tmin}°";
                Jour1TempMax = $"{mr.fcst_day_1.tmax}°";
                Jour1TempMin = $"{mr.fcst_day_1.tmin}°";
                Jour2TempMax = $"{mr.fcst_day_2.tmax}°";
                Jour2TempMin = $"{mr.fcst_day_2.tmin}°";
                Jour3TempMax = $"{mr.fcst_day_3.tmax}°";
                Jour3TempMin = $"{mr.fcst_day_3.tmin}°";
                Jour4TempMax = $"{mr.fcst_day_4.tmax}°";
                Jour4TempMin = $"{mr.fcst_day_4.tmin}°";
            }
        }
    }
}
