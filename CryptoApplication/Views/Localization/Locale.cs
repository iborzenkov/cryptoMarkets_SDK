using Genesis.Localization;
using Genesis.Localization.Mappings;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Views.Interfaces;

namespace Views.Localization
{
    public class Locale
    {
        public LocalizationManager LocalizationManager { get; }
        private LocalizationPackage LocalizationPackage { get; set; }

        private const string DefaultLocalization = "us";

        private static Locale _instance;

        private Locale()
        {
            LocalizationManager = new LocalizationManager { BasePath = AppDomain.CurrentDomain.BaseDirectory };
            LocalizationManager.Initialize();
            try
            {
                LocalizationManager.DetectAllLocalizations();
            }
            catch (LocalizationException ex)
            {
                MessageBox.Show(ex.Message, @"Localization Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LocalizationPackage = LocalizationManager.Load(DefaultLocalization);
        }

        public static Locale Instance => _instance ?? (_instance = new Locale());

        public void SetPackage(string name)
        {
            LocalizationPackage = LocalizationManager.Load(name);

            _views.ForEach(LocalizeView);
        }

        public string Localize(string key)
        {
            return LocalizationPackage[key];
        }

        private readonly List<object> _views = new List<object>();

        public void RegisterView(object view)
        {
            _views.Add(view);

            LocalizeView(view);
        }

        public void UnRegisterView(object view)
        {
            _views.Remove(view);
        }

        private void LocalizeView(object view)
        {
            var mapper = new LocalizationMapper { Current = LocalizationPackage };
            mapper.Localize(view);

            var localizable = view as ILocalizableView;
            localizable?.ApplyLocale();
        }
    }
}