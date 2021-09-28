﻿using Annamaria.MostriVsEroi.Core.Entities;
using Annamaria.MostriVsEroi.Core.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annamaria.MostriVsEroi.Mock
{
    public class RepositoryCategorie: IRepositoryCategorie
    {
        public static List<Categoria> categorie = new List<Categoria>()
        {
            //Categorie per gli eroi
            new Categoria {Id = 1, Nome = "Guerriero", Flag = false},
            new Categoria {Id = 2, Nome = "Mago", Flag = false},

            //Categorie per i mostri
            new Categoria {Id = 3, Nome = "Cultista", Flag = true},
            new Categoria {Id = 4, Nome = "Orco", Flag = true},
            new Categoria {Id = 5, Nome = "Signore del male", Flag = true},

        };
    }
}
