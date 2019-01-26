﻿using Domen;
using Sesija;
using System;

namespace SistemskeOperacije
{
    public abstract class OpstaSO
   {
        protected object rezultat;

        #region Get, Set
        public object Rezultat
        {
            get { return rezultat; }
            set { rezultat = value; }
        }
        #endregion

        public bool IzvrsiSO(IDomenskiObjekat objekat)
        {
            bool izvrseno = false;
            try
            {
                Broker.DajInstancu().OtvoriKonekciju();
                Broker.DajInstancu().ZapocniTransakciju();
                izvrseno = Izvrsi(objekat);
                Broker.DajInstancu().ZatvoriCitac();
                if (izvrseno)
                {
                    Broker.DajInstancu().PotvrdiTransakciju();
                }
                else
                {
                    Broker.DajInstancu().PonistiTransakciju();
                }
                return izvrseno;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
                return false;
            }
            finally
            {
                Broker.DajInstancu().ZatvoriKonekciju();
            }
        }

        protected abstract bool Izvrsi(IDomenskiObjekat objekat);
    }
}
