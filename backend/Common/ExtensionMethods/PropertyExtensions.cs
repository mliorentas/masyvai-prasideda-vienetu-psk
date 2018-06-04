using System;
using Core;
using MasyvaiPrasidedaVienetu.WebEndpoints.Models;

namespace MasyvaiPrasidedaVienetu.WebEndpoints.ExtensionMethods
{
    public static class PropertyExtensions
    {
        public static PropertyViewModel ToViewModel(this Properties properties)
        {
            PropertyViewModel parsedProperties;
            try
            {
                parsedProperties = new PropertyViewModel
                {
                    Id = properties.Id,
                    Ilgis = properties.Ilgis,
                    Plotis = properties.Plotis,
                    Ratai = properties.Ratai,
                    Guoliai = properties.Guoliai,
                    MaksimalusSvoris = properties.MaksimalusSvoris,
                    Spalva= properties.Spalva,
                    Asys= properties.Asys,
                    Paskirtis = properties.Paskirtis,
                    Gamintojas = properties.Gamintojas,
                    Dydis = properties.Dydis,
                    Storis = properties.Storis,
                    Kietumas = properties.Kietumas,
                    Skirta = properties.Skirta,
                };
            }
            catch (Exception)
            {
                parsedProperties = new PropertyViewModel();
            }
            return parsedProperties;
        }

        public static Properties ToEntity(this PropertyViewModel properties)
        {
            Properties parsedProperties;
            try
            {
                parsedProperties = new Properties
                {
                    Id = properties.Id,
                    Ilgis = properties.Ilgis,
                    Plotis = properties.Plotis,
                    Ratai = properties.Ratai,
                    Guoliai = properties.Guoliai,
                    MaksimalusSvoris = properties.MaksimalusSvoris,
                    Spalva = properties.Spalva,
                    Asys = properties.Asys,
                    Paskirtis = properties.Paskirtis,
                    Gamintojas = properties.Gamintojas,
                    Dydis = properties.Dydis,
                    Storis = properties.Storis,
                    Kietumas = properties.Kietumas,
                    Skirta = properties.Skirta,
                };
            }
            catch (Exception)
            {
                parsedProperties = new Properties();
            }
            return parsedProperties;
        }
    }
}