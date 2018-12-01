namespace definicje_zmiennych
{
    public enum rodzaj_biletu {
        BILET_JEDNORAZOWY,
        BILET_JEDNORAZOWY_METROPOLITARNY,
        BILET_OKRESOWY,
        BRAK,
    };

    public enum rodzaj_platnosci
    {
        GOTOWKA,
        KARTA
    };

    public enum status
    {
        WYDRUKOWANO_BILETY,
        BRAK,
    }

    public enum wybrana_platnosc
    {
        GOTOWKA,
        GOTOWKA_BEZ_RESZTY,
        KARTA_PLATNICZA,
        PLATNOSC_ANULOWANA,
        BRAK,
    }

    public enum wlozony_bilet_okresowy
    {
        KARTA_MIEJSKA,
        LEGITYMACJA_STUDENCKA,
        BRAK
    }

    public enum przewoznik
    {
        ZKM,
        MZKG,
        BRAK
    } 

    public enum okres_biletu
    {
        MIESIECZNY,
        _30_DNIOWY,
        SEMESTRALNY,
        BRAK
    }

    public enum typ_biletu
    {
        IMIENNY,
        NA_OKAZICIELA,
        BRAK
    }

    public enum dlugosc_waznosci
    {
        OD_PON_DO_PT,
        CALY_TYDZIEN,
        _4_MIESIECZNY,
        _5_MIESIECZNY,
        BRAK
    }

    public enum okres_semestru
    {
        LETNI_4_MIES,
        LETNI_5_MIES,
        ZIMOWY_4_MIES,
        ZIMOWY_5_MIES,
        BRAK
    }

    public enum rodzaj_ulgi
    {
        NORMALNY,
        ULGOWY,
        BRAK
    }

    public enum obszar_waznosci
    {
        GDYNIA,
        SOPOT,
        RUMIA,
        KOSAKOWO_GM,
        ZUKOWO_GM,
        SZEMUD_GM,
        WEJHEROWO_GM,
        RUMA_REDA_WEJHEROWO,
        RUMIA_WEJHEROWO_GM,
        SIEC_KOMUNIKACYJNA,
        METROPOLITALNY,
        BRAK
    }

    public enum rodzaj_linii
    {
        ZWYKLE,
        NOCNE,
        BRAK
    }

    public static class status_biletomatu
    {
        public static status status_zakupu;
        public static wybrana_platnosc rodzaj_platnosci;
        public static rodzaj_biletu wybrany_bilet;
        public static wlozony_bilet_okresowy karta_zblizeniowa;
        public static bool powitanie;

        public static void wyczysc()
        {
            status_zakupu = status.BRAK;
            rodzaj_platnosci = wybrana_platnosc.BRAK;
            wybrany_bilet = rodzaj_biletu.BRAK;
            karta_zblizeniowa = wlozony_bilet_okresowy.BRAK;
        }
    }

    public static class bilety_jednorazowe
    {
        public static int bilet1_normalny;
        public static int bilet1_ulgowy;
        public static int bilet2_normalny;
        public static int bilet2_ulgowy;
        public static int bilet3_normalny;
        public static int bilet3_ulgowy;
        public static int bilet4_normalny;
        public static int bilet4_ulgowy;
        public static int bilet5_normalny;
        public static int bilet5_ulgowy;

        public static void czysc_ilosc()
        {
            bilet1_normalny = 0;
            bilet1_ulgowy = 0;
            bilet2_normalny = 0;
            bilet2_ulgowy = 0;
            bilet3_normalny = 0;
            bilet3_ulgowy = 0;
            bilet4_normalny = 0;
            bilet4_ulgowy = 0;
            bilet5_normalny = 0;
            bilet5_ulgowy = 0;
        }

        public static int liczba_biletow()
        {
            return bilet1_normalny + bilet1_ulgowy + bilet2_normalny + bilet2_ulgowy + bilet3_normalny + bilet3_ulgowy + bilet4_normalny + bilet4_ulgowy + bilet5_normalny + bilet5_ulgowy;
        }
    }

    public static class bilety_jednorazowe_metropolitarne
    {
        public static int bilet1_normalny;
        public static int bilet1_ulgowy;
        public static int bilet2_normalny;
        public static int bilet2_ulgowy;
        public static int bilet3_normalny;
        public static int bilet3_ulgowy;
        public static int bilet4_normalny_ZTM;
        public static int bilet4_ulgowy_ZTM;
        public static int bilet4_normalny_ZKM;
        public static int bilet4_ulgowy_ZKM;
        public static int bilet4_normalny_MZK;
        public static int bilet4_ulgowy_MZK;
        public static int bilet5_normalny;
        public static int bilet5_ulgowy;
        public static int bilet6_normalny;
        public static int bilet6_ulgowy;
        public static int bilet7_normalny;
        public static int bilet7_ulgowy;

        public static void czysc_ilosc()
        {
            bilet1_normalny = 0;
            bilet1_ulgowy = 0;
            bilet2_normalny = 0;
            bilet2_ulgowy = 0;
            bilet3_normalny = 0;
            bilet3_ulgowy = 0;
            bilet4_normalny_ZTM = 0;
            bilet4_ulgowy_ZTM = 0;
            bilet4_normalny_ZKM = 0;
            bilet4_ulgowy_ZKM = 0;
            bilet4_normalny_MZK = 0;
            bilet4_ulgowy_MZK = 0;
            bilet5_normalny = 0;
            bilet5_ulgowy = 0;
            bilet6_normalny = 0;
            bilet6_ulgowy = 0;
            bilet7_normalny = 0;
            bilet7_ulgowy = 0;
        }

        public static int liczba_biletow()
        {
            return bilet1_normalny + bilet1_ulgowy + bilet2_normalny + bilet2_ulgowy + bilet3_normalny + bilet3_ulgowy + bilet4_normalny_ZTM + bilet4_ulgowy_ZTM + bilet4_normalny_ZKM + bilet4_ulgowy_ZKM + bilet4_normalny_MZK + bilet4_ulgowy_MZK + bilet5_normalny + bilet5_ulgowy;
        }
    }

    public static class bilet_okresowy
    {
        public static przewoznik przewoznik;
        public static wlozony_bilet_okresowy wlozony_Bilet_Okresowy; //czy legitymacja czy karta miejska
        public static okres_biletu okres_Biletu;
        public static typ_biletu typ_Biletu;
        public static dlugosc_waznosci dlugosc_Waznosci;
        public static okres_semestru okres_Semestru;
        public static rodzaj_ulgi rodzaj_Ulgi;
        public static obszar_waznosci obszar_Waznosci;
        public static rodzaj_linii rodzaj_Linii;


        public static void czysc_bilet()
        {
            przewoznik = przewoznik.BRAK;
            wlozony_Bilet_Okresowy = wlozony_bilet_okresowy.BRAK;
            okres_Biletu = okres_biletu.BRAK;
            typ_Biletu = typ_biletu.BRAK;
            dlugosc_Waznosci = dlugosc_waznosci.BRAK;
            okres_Semestru = okres_semestru.BRAK;
            rodzaj_Ulgi = rodzaj_ulgi.BRAK;
            obszar_Waznosci = obszar_waznosci.BRAK;
            rodzaj_Linii = rodzaj_linii.BRAK;
        }

        public static double cena_bilet()
        {
            double cena = 0;
            switch (przewoznik)
            {
                case przewoznik.ZKM:
                    switch (okres_Biletu)
                    {
                        case okres_biletu.MIESIECZNY:
                            switch (typ_Biletu)
                            {
                                case typ_biletu.IMIENNY:
                                    switch (dlugosc_Waznosci)
                                    {
                                        case dlugosc_waznosci.OD_PON_DO_PT:
                                            switch (rodzaj_Ulgi)
                                            {
                                                case rodzaj_ulgi.NORMALNY:
                                                    switch (rodzaj_Linii)
                                                    {
                                                        case rodzaj_linii.ZWYKLE:
                                                            switch (obszar_Waznosci)
                                                            {
                                                                case obszar_waznosci.GDYNIA:
                                                                    cena = 72.0;
                                                                    break;
                                                                default:
                                                                    break;
                                                            }
                                                            break;
                                                        case rodzaj_linii.NOCNE:
                                                            switch (obszar_Waznosci)
                                                            {
                                                                case obszar_waznosci.GDYNIA:
                                                                    cena = 86.0;
                                                                    break;
                                                                case obszar_waznosci.SOPOT:
                                                                    cena = 58.0;
                                                                    break;
                                                                case obszar_waznosci.RUMIA:
                                                                    cena = 58.0;
                                                                    break;
                                                                case obszar_waznosci.KOSAKOWO_GM:
                                                                    cena = 58.0;
                                                                    break;
                                                                case obszar_waznosci.ZUKOWO_GM:
                                                                    cena = 58.0;
                                                                    break;
                                                                case obszar_waznosci.SZEMUD_GM:
                                                                    cena = 58.0;
                                                                    break;
                                                                case obszar_waznosci.WEJHEROWO_GM:
                                                                    cena = 58.0;
                                                                    break;
                                                                case obszar_waznosci.RUMA_REDA_WEJHEROWO:
                                                                    cena = 74.0;
                                                                    break;
                                                                case obszar_waznosci.RUMIA_WEJHEROWO_GM:
                                                                    cena = 74.0;
                                                                    break;
                                                                case obszar_waznosci.SIEC_KOMUNIKACYJNA:
                                                                    cena = 96.0;
                                                                    break;
                                                                case obszar_waznosci.METROPOLITALNY:
                                                                    break;
                                                                case obszar_waznosci.BRAK:
                                                                    cena = -1.0;
                                                                    break;
                                                                default:
                                                                    break;
                                                            }
                                                            break;
                                                        case rodzaj_linii.BRAK:
                                                            cena = -1.0;
                                                            break;
                                                        default:
                                                            break;
                                                    }
                                                    break;
                                                case rodzaj_ulgi.ULGOWY:
                                                    switch (rodzaj_Linii)
                                                    {
                                                        case rodzaj_linii.ZWYKLE:
                                                            switch (obszar_Waznosci)
                                                            {
                                                                case obszar_waznosci.GDYNIA:
                                                                    cena = 36.0;
                                                                    break;
                                                                default:
                                                                    break;
                                                            }
                                                            break;
                                                        case rodzaj_linii.NOCNE:
                                                            switch (obszar_Waznosci)
                                                            {
                                                                case obszar_waznosci.GDYNIA:
                                                                    cena = 43.0;
                                                                    break;
                                                                case obszar_waznosci.SOPOT:
                                                                    cena = 29.0;
                                                                    break;
                                                                case obszar_waznosci.RUMIA:
                                                                    cena = 29.0;
                                                                    break;
                                                                case obszar_waznosci.KOSAKOWO_GM:
                                                                    cena = 29.0;
                                                                    break;
                                                                case obszar_waznosci.ZUKOWO_GM:
                                                                    cena = 29.0;
                                                                    break;
                                                                case obszar_waznosci.SZEMUD_GM:
                                                                    cena = 29.0;
                                                                    break;
                                                                case obszar_waznosci.WEJHEROWO_GM:
                                                                    cena = 29.0;
                                                                    break;
                                                                case obszar_waznosci.RUMA_REDA_WEJHEROWO:
                                                                    cena = 37.0;
                                                                    break;
                                                                case obszar_waznosci.RUMIA_WEJHEROWO_GM:
                                                                    cena = 37.0;
                                                                    break;
                                                                case obszar_waznosci.SIEC_KOMUNIKACYJNA:
                                                                    cena = 48.0;
                                                                    break;
                                                                case obszar_waznosci.METROPOLITALNY:
                                                                    cena = -1.0;
                                                                    break;
                                                                case obszar_waznosci.BRAK:
                                                                    cena = -1.0;
                                                                    break;
                                                                default:
                                                                    break;
                                                            }
                                                            break;
                                                        case rodzaj_linii.BRAK:
                                                            cena = -1.0;
                                                            break;
                                                        default:
                                                            break;
                                                    }
                                                    break;
                                                case rodzaj_ulgi.BRAK:
                                                    cena = -1.0;
                                                    break;
                                                default:
                                                    break;
                                            }
                                            break;
                                        case dlugosc_waznosci.CALY_TYDZIEN:
                                            switch (rodzaj_Ulgi)
                                            {
                                                case rodzaj_ulgi.NORMALNY:
                                                    switch (rodzaj_Linii)
                                                    {
                                                        case rodzaj_linii.ZWYKLE:
                                                            switch (obszar_Waznosci)
                                                            {
                                                                case obszar_waznosci.GDYNIA:
                                                                    cena = 82.0;
                                                                    break;
                                                                default:
                                                                    break;
                                                            }
                                                            break;
                                                        case rodzaj_linii.NOCNE:
                                                            switch (obszar_Waznosci)
                                                            {
                                                                case obszar_waznosci.GDYNIA:
                                                                    cena = 94.0;
                                                                    break;
                                                                case obszar_waznosci.SOPOT:
                                                                    cena = 64.0;
                                                                    break;
                                                                case obszar_waznosci.RUMIA:
                                                                    cena = 64.0;
                                                                    break;
                                                                case obszar_waznosci.KOSAKOWO_GM:
                                                                    cena = 64.0;
                                                                    break;
                                                                case obszar_waznosci.ZUKOWO_GM:
                                                                    cena = 64.0;
                                                                    break;
                                                                case obszar_waznosci.SZEMUD_GM:
                                                                    cena = 64.0;
                                                                    break;
                                                                case obszar_waznosci.WEJHEROWO_GM:
                                                                    cena = 64.0;
                                                                    break;
                                                                case obszar_waznosci.RUMA_REDA_WEJHEROWO:
                                                                    cena = 84.0;
                                                                    break;
                                                                case obszar_waznosci.RUMIA_WEJHEROWO_GM:
                                                                    cena = 84.0;
                                                                    break;
                                                                case obszar_waznosci.SIEC_KOMUNIKACYJNA:
                                                                    cena = 104.0;
                                                                    break;
                                                                case obszar_waznosci.METROPOLITALNY:
                                                                    break;
                                                                case obszar_waznosci.BRAK:
                                                                    cena = -1.0;
                                                                    break;
                                                                default:
                                                                    break;
                                                            }
                                                            break;
                                                        case rodzaj_linii.BRAK:
                                                            cena = -1.0;
                                                            break;
                                                        default:
                                                            break;
                                                    }
                                                    break;
                                                case rodzaj_ulgi.ULGOWY:
                                                    switch (rodzaj_Linii)
                                                    {
                                                        case rodzaj_linii.ZWYKLE:
                                                            switch (obszar_Waznosci)
                                                            {
                                                                case obszar_waznosci.GDYNIA:
                                                                    cena = 41.0;
                                                                    break;
                                                                default:
                                                                    break;
                                                            }
                                                            break;
                                                        case rodzaj_linii.NOCNE:
                                                            switch (obszar_Waznosci)
                                                            {
                                                                case obszar_waznosci.GDYNIA:
                                                                    cena = 47.0;
                                                                    break;
                                                                case obszar_waznosci.SOPOT:
                                                                    cena = 32.0;
                                                                    break;
                                                                case obszar_waznosci.RUMIA:
                                                                    cena = 32.0;
                                                                    break;
                                                                case obszar_waznosci.KOSAKOWO_GM:
                                                                    cena = 32.0;
                                                                    break;
                                                                case obszar_waznosci.ZUKOWO_GM:
                                                                    cena = 32.0;
                                                                    break;
                                                                case obszar_waznosci.SZEMUD_GM:
                                                                    cena = 32.0;
                                                                    break;
                                                                case obszar_waznosci.WEJHEROWO_GM:
                                                                    cena = 32.0;
                                                                    break;
                                                                case obszar_waznosci.RUMA_REDA_WEJHEROWO:
                                                                    cena = 42.0;
                                                                    break;
                                                                case obszar_waznosci.RUMIA_WEJHEROWO_GM:
                                                                    cena = 42.0;
                                                                    break;
                                                                case obszar_waznosci.SIEC_KOMUNIKACYJNA:
                                                                    cena = 52.0;
                                                                    break;
                                                                case obszar_waznosci.METROPOLITALNY:
                                                                    cena = -1.0;
                                                                    break;
                                                                case obszar_waznosci.BRAK:
                                                                    cena = -1.0;
                                                                    break;
                                                                default:
                                                                    break;
                                                            }
                                                            break;
                                                        case rodzaj_linii.BRAK:
                                                            cena = -1.0;
                                                            break;
                                                        default:
                                                            break;
                                                    }
                                                    break;
                                                case rodzaj_ulgi.BRAK:
                                                    cena = -1.0;
                                                    break;
                                                default:
                                                    break;
                                            }
                                            break;
                                        case dlugosc_waznosci._4_MIESIECZNY:
                                            switch (rodzaj_Ulgi)
                                            {
                                                case rodzaj_ulgi.NORMALNY:
                                                    cena = -1.0;
                                                    break;
                                                case rodzaj_ulgi.ULGOWY:
                                                    switch (okres_Semestru)
                                                    {
                                                        case okres_semestru.LETNI_4_MIES:
                                                            switch (rodzaj_Linii)
                                                            {
                                                                case rodzaj_linii.ZWYKLE:
                                                                    switch (obszar_Waznosci)
                                                                    {
                                                                        case obszar_waznosci.GDYNIA:
                                                                            cena = 156.0;
                                                                            break;
                                                                        default:
                                                                            break;
                                                                    }
                                                                    break;
                                                                case rodzaj_linii.NOCNE:
                                                                    switch (obszar_Waznosci)
                                                                    {
                                                                        case obszar_waznosci.GDYNIA:
                                                                            cena = 179.0;
                                                                            break;
                                                                        case obszar_waznosci.SOPOT:
                                                                            cena = 122.0;
                                                                            break;
                                                                        case obszar_waznosci.RUMIA:
                                                                            cena = 122.0;
                                                                            break;
                                                                        case obszar_waznosci.KOSAKOWO_GM:
                                                                            cena = 122.0;
                                                                            break;
                                                                        case obszar_waznosci.ZUKOWO_GM:
                                                                            cena = 122.0;
                                                                            break;
                                                                        case obszar_waznosci.SZEMUD_GM:
                                                                            cena = 122.0;
                                                                            break;
                                                                        case obszar_waznosci.WEJHEROWO_GM:
                                                                            cena = 122.0;
                                                                            break;
                                                                        case obszar_waznosci.RUMA_REDA_WEJHEROWO:
                                                                            cena = 160.0;
                                                                            break;
                                                                        case obszar_waznosci.RUMIA_WEJHEROWO_GM:
                                                                            cena = 160.0;
                                                                            break;
                                                                        case obszar_waznosci.SIEC_KOMUNIKACYJNA:
                                                                            cena = 198.0;
                                                                            break;
                                                                        case obszar_waznosci.METROPOLITALNY:
                                                                            cena = -1.0;
                                                                            break;
                                                                        case obszar_waznosci.BRAK:
                                                                            cena = -1.0;
                                                                            break;
                                                                        default:
                                                                            break;
                                                                    }
                                                                    break;
                                                                case rodzaj_linii.BRAK:
                                                                    cena = -1.0;
                                                                    break;
                                                                default:
                                                                    break;
                                                            }
                                                            break;
                                                        case okres_semestru.LETNI_5_MIES:
                                                            switch (rodzaj_Linii)
                                                            {
                                                                case rodzaj_linii.ZWYKLE:
                                                                    switch (obszar_Waznosci)
                                                                    {
                                                                        case obszar_waznosci.GDYNIA:
                                                                            cena = 195.0;
                                                                            break;
                                                                        default:
                                                                            break;
                                                                    }
                                                                    break;
                                                                case rodzaj_linii.NOCNE:
                                                                    switch (obszar_Waznosci)
                                                                    {
                                                                        case obszar_waznosci.GDYNIA:
                                                                            cena = 223.0;
                                                                            break;
                                                                        case obszar_waznosci.SOPOT:
                                                                            cena = 152.0;
                                                                            break;
                                                                        case obszar_waznosci.RUMIA:
                                                                            cena = 152.0;
                                                                            break;
                                                                        case obszar_waznosci.KOSAKOWO_GM:
                                                                            cena = 152.0;
                                                                            break;
                                                                        case obszar_waznosci.ZUKOWO_GM:
                                                                            cena = 152.0;
                                                                            break;
                                                                        case obszar_waznosci.SZEMUD_GM:
                                                                            cena = 152.0;
                                                                            break;
                                                                        case obszar_waznosci.WEJHEROWO_GM:
                                                                            cena = 152.0;
                                                                            break;
                                                                        case obszar_waznosci.RUMA_REDA_WEJHEROWO:
                                                                            cena = 200.0;
                                                                            break;
                                                                        case obszar_waznosci.RUMIA_WEJHEROWO_GM:
                                                                            cena = 200.0;
                                                                            break;
                                                                        case obszar_waznosci.SIEC_KOMUNIKACYJNA:
                                                                            cena = 247.0;
                                                                            break;
                                                                        case obszar_waznosci.METROPOLITALNY:
                                                                            cena = -1.0;
                                                                            break;
                                                                        case obszar_waznosci.BRAK:
                                                                            cena = -1.0;
                                                                            break;
                                                                        default:
                                                                            break;
                                                                    }
                                                                    break;
                                                                case rodzaj_linii.BRAK:
                                                                    cena = -1.0;
                                                                    break;
                                                                default:
                                                                    break;
                                                            }
                                                            break;
                                                        case okres_semestru.ZIMOWY_4_MIES:
                                                            switch (rodzaj_Linii)
                                                            {
                                                                case rodzaj_linii.ZWYKLE:
                                                                    switch (obszar_Waznosci)
                                                                    {
                                                                        case obszar_waznosci.GDYNIA:
                                                                            cena = 156.0;
                                                                            break;
                                                                        default:
                                                                            break;
                                                                    }
                                                                    break;
                                                                case rodzaj_linii.NOCNE:
                                                                    switch (obszar_Waznosci)
                                                                    {
                                                                        case obszar_waznosci.GDYNIA:
                                                                            cena = 179.0;
                                                                            break;
                                                                        case obszar_waznosci.SOPOT:
                                                                            cena = 122.0;
                                                                            break;
                                                                        case obszar_waznosci.RUMIA:
                                                                            cena = 122.0;
                                                                            break;
                                                                        case obszar_waznosci.KOSAKOWO_GM:
                                                                            cena = 122.0;
                                                                            break;
                                                                        case obszar_waznosci.ZUKOWO_GM:
                                                                            cena = 122.0;
                                                                            break;
                                                                        case obszar_waznosci.SZEMUD_GM:
                                                                            cena = 122.0;
                                                                            break;
                                                                        case obszar_waznosci.WEJHEROWO_GM:
                                                                            cena = 122.0;
                                                                            break;
                                                                        case obszar_waznosci.RUMA_REDA_WEJHEROWO:
                                                                            cena = 160.0;
                                                                            break;
                                                                        case obszar_waznosci.RUMIA_WEJHEROWO_GM:
                                                                            cena = 160.0;
                                                                            break;
                                                                        case obszar_waznosci.SIEC_KOMUNIKACYJNA:
                                                                            cena = 198.0;
                                                                            break;
                                                                        case obszar_waznosci.METROPOLITALNY:
                                                                            cena = -1.0;
                                                                            break;
                                                                        case obszar_waznosci.BRAK:
                                                                            cena = -1.0;
                                                                            break;
                                                                        default:
                                                                            break;
                                                                    }
                                                                    break;
                                                                case rodzaj_linii.BRAK:
                                                                    cena = -1.0;
                                                                    break;
                                                                default:
                                                                    break;
                                                            }
                                                            break;
                                                        case okres_semestru.ZIMOWY_5_MIES:
                                                            switch (rodzaj_Linii)
                                                            {
                                                                case rodzaj_linii.ZWYKLE:
                                                                    switch (obszar_Waznosci)
                                                                    {
                                                                        case obszar_waznosci.GDYNIA:
                                                                            cena = 195.0;
                                                                            break;
                                                                        default:
                                                                            break;
                                                                    }
                                                                    break;
                                                                case rodzaj_linii.NOCNE:
                                                                    switch (obszar_Waznosci)
                                                                    {
                                                                        case obszar_waznosci.GDYNIA:
                                                                            cena = 223.0;
                                                                            break;
                                                                        case obszar_waznosci.SOPOT:
                                                                            cena = 152.0;
                                                                            break;
                                                                        case obszar_waznosci.RUMIA:
                                                                            cena = 152.0;
                                                                            break;
                                                                        case obszar_waznosci.KOSAKOWO_GM:
                                                                            cena = 152.0;
                                                                            break;
                                                                        case obszar_waznosci.ZUKOWO_GM:
                                                                            cena = 152.0;
                                                                            break;
                                                                        case obszar_waznosci.SZEMUD_GM:
                                                                            cena = 152.0;
                                                                            break;
                                                                        case obszar_waznosci.WEJHEROWO_GM:
                                                                            cena = 152.0;
                                                                            break;
                                                                        case obszar_waznosci.RUMA_REDA_WEJHEROWO:
                                                                            cena = 200.0;
                                                                            break;
                                                                        case obszar_waznosci.RUMIA_WEJHEROWO_GM:
                                                                            cena = 200.0;
                                                                            break;
                                                                        case obszar_waznosci.SIEC_KOMUNIKACYJNA:
                                                                            cena = 247.0;
                                                                            break;
                                                                        case obszar_waznosci.METROPOLITALNY:
                                                                            cena = -1.0;
                                                                            break;
                                                                        case obszar_waznosci.BRAK:
                                                                            cena = -1.0;
                                                                            break;
                                                                        default:
                                                                            break;
                                                                    }
                                                                    break;
                                                                case rodzaj_linii.BRAK:
                                                                    cena = -1.0;
                                                                    break;
                                                                default:
                                                                    break;
                                                            }
                                                            break;
                                                        case okres_semestru.BRAK:
                                                            cena = -1.0;
                                                            break;
                                                        default:
                                                            break;
                                                    }
                                                    break;
                                                case rodzaj_ulgi.BRAK:
                                                    cena = -1.0;
                                                    break;
                                                default:
                                                    break;
                                            }
                                            break;
                                        case dlugosc_waznosci._5_MIESIECZNY:
                                            switch (rodzaj_Ulgi)
                                            {
                                                case rodzaj_ulgi.NORMALNY:
                                                    cena = -1.0;
                                                    break;
                                                case rodzaj_ulgi.ULGOWY:
                                                    switch (okres_Semestru)
                                                    {
                                                        case okres_semestru.LETNI_4_MIES:
                                                            switch (rodzaj_Linii)
                                                            {
                                                                case rodzaj_linii.ZWYKLE:
                                                                    switch (obszar_Waznosci)
                                                                    {
                                                                        case obszar_waznosci.GDYNIA:
                                                                            cena = 156.0;
                                                                            break;
                                                                        default:
                                                                            break;
                                                                    }
                                                                    break;
                                                                case rodzaj_linii.NOCNE:
                                                                    switch (obszar_Waznosci)
                                                                    {
                                                                        case obszar_waznosci.GDYNIA:
                                                                            cena = 179.0;
                                                                            break;
                                                                        case obszar_waznosci.SOPOT:
                                                                            cena = 122.0;
                                                                            break;
                                                                        case obszar_waznosci.RUMIA:
                                                                            cena = 122.0;
                                                                            break;
                                                                        case obszar_waznosci.KOSAKOWO_GM:
                                                                            cena = 122.0;
                                                                            break;
                                                                        case obszar_waznosci.ZUKOWO_GM:
                                                                            cena = 122.0;
                                                                            break;
                                                                        case obszar_waznosci.SZEMUD_GM:
                                                                            cena = 122.0;
                                                                            break;
                                                                        case obszar_waznosci.WEJHEROWO_GM:
                                                                            cena = 122.0;
                                                                            break;
                                                                        case obszar_waznosci.RUMA_REDA_WEJHEROWO:
                                                                            cena = 160.0;
                                                                            break;
                                                                        case obszar_waznosci.RUMIA_WEJHEROWO_GM:
                                                                            cena = 160.0;
                                                                            break;
                                                                        case obszar_waznosci.SIEC_KOMUNIKACYJNA:
                                                                            cena = 198.0;
                                                                            break;
                                                                        case obszar_waznosci.METROPOLITALNY:
                                                                            cena = -1.0;
                                                                            break;
                                                                        case obszar_waznosci.BRAK:
                                                                            cena = -1.0;
                                                                            break;
                                                                        default:
                                                                            break;
                                                                    }
                                                                    break;
                                                                case rodzaj_linii.BRAK:
                                                                    cena = -1.0;
                                                                    break;
                                                                default:
                                                                    break;
                                                            }
                                                            break;
                                                        case okres_semestru.LETNI_5_MIES:
                                                            switch (rodzaj_Linii)
                                                            {
                                                                case rodzaj_linii.ZWYKLE:
                                                                    switch (obszar_Waznosci)
                                                                    {
                                                                        case obszar_waznosci.GDYNIA:
                                                                            cena = 195.0;
                                                                            break;
                                                                        default:
                                                                            break;
                                                                    }
                                                                    break;
                                                                case rodzaj_linii.NOCNE:
                                                                    switch (obszar_Waznosci)
                                                                    {
                                                                        case obszar_waznosci.GDYNIA:
                                                                            cena = 223.0;
                                                                            break;
                                                                        case obszar_waznosci.SOPOT:
                                                                            cena = 152.0;
                                                                            break;
                                                                        case obszar_waznosci.RUMIA:
                                                                            cena = 152.0;
                                                                            break;
                                                                        case obszar_waznosci.KOSAKOWO_GM:
                                                                            cena = 152.0;
                                                                            break;
                                                                        case obszar_waznosci.ZUKOWO_GM:
                                                                            cena = 152.0;
                                                                            break;
                                                                        case obszar_waznosci.SZEMUD_GM:
                                                                            cena = 152.0;
                                                                            break;
                                                                        case obszar_waznosci.WEJHEROWO_GM:
                                                                            cena = 152.0;
                                                                            break;
                                                                        case obszar_waznosci.RUMA_REDA_WEJHEROWO:
                                                                            cena = 200.0;
                                                                            break;
                                                                        case obszar_waznosci.RUMIA_WEJHEROWO_GM:
                                                                            cena = 200.0;
                                                                            break;
                                                                        case obszar_waznosci.SIEC_KOMUNIKACYJNA:
                                                                            cena = 247.0;
                                                                            break;
                                                                        case obszar_waznosci.METROPOLITALNY:
                                                                            cena = -1.0;
                                                                            break;
                                                                        case obszar_waznosci.BRAK:
                                                                            cena = -1.0;
                                                                            break;
                                                                        default:
                                                                            break;
                                                                    }
                                                                    break;
                                                                case rodzaj_linii.BRAK:
                                                                    cena = -1.0;
                                                                    break;
                                                                default:
                                                                    break;
                                                            }
                                                            break;
                                                        case okres_semestru.ZIMOWY_4_MIES:
                                                            switch (rodzaj_Linii)
                                                            {
                                                                case rodzaj_linii.ZWYKLE:
                                                                    switch (obszar_Waznosci)
                                                                    {
                                                                        case obszar_waznosci.GDYNIA:
                                                                            cena = 156.0;
                                                                            break;
                                                                        default:
                                                                            break;
                                                                    }
                                                                    break;
                                                                case rodzaj_linii.NOCNE:
                                                                    switch (obszar_Waznosci)
                                                                    {
                                                                        case obszar_waznosci.GDYNIA:
                                                                            cena = 179.0;
                                                                            break;
                                                                        case obszar_waznosci.SOPOT:
                                                                            cena = 122.0;
                                                                            break;
                                                                        case obszar_waznosci.RUMIA:
                                                                            cena = 122.0;
                                                                            break;
                                                                        case obszar_waznosci.KOSAKOWO_GM:
                                                                            cena = 122.0;
                                                                            break;
                                                                        case obszar_waznosci.ZUKOWO_GM:
                                                                            cena = 122.0;
                                                                            break;
                                                                        case obszar_waznosci.SZEMUD_GM:
                                                                            cena = 122.0;
                                                                            break;
                                                                        case obszar_waznosci.WEJHEROWO_GM:
                                                                            cena = 122.0;
                                                                            break;
                                                                        case obszar_waznosci.RUMA_REDA_WEJHEROWO:
                                                                            cena = 160.0;
                                                                            break;
                                                                        case obszar_waznosci.RUMIA_WEJHEROWO_GM:
                                                                            cena = 160.0;
                                                                            break;
                                                                        case obszar_waznosci.SIEC_KOMUNIKACYJNA:
                                                                            cena = 198.0;
                                                                            break;
                                                                        case obszar_waznosci.METROPOLITALNY:
                                                                            cena = -1.0;
                                                                            break;
                                                                        case obszar_waznosci.BRAK:
                                                                            cena = -1.0;
                                                                            break;
                                                                        default:
                                                                            break;
                                                                    }
                                                                    break;
                                                                case rodzaj_linii.BRAK:
                                                                    cena = -1.0;
                                                                    break;
                                                                default:
                                                                    break;
                                                            }
                                                            break;
                                                        case okres_semestru.ZIMOWY_5_MIES:
                                                            switch (rodzaj_Linii)
                                                            {
                                                                case rodzaj_linii.ZWYKLE:
                                                                    switch (obszar_Waznosci)
                                                                    {
                                                                        case obszar_waznosci.GDYNIA:
                                                                            cena = 195.0;
                                                                            break;
                                                                        default:
                                                                            break;
                                                                    }
                                                                    break;
                                                                case rodzaj_linii.NOCNE:
                                                                    switch (obszar_Waznosci)
                                                                    {
                                                                        case obszar_waznosci.GDYNIA:
                                                                            cena = 223.0;
                                                                            break;
                                                                        case obszar_waznosci.SOPOT:
                                                                            cena = 152.0;
                                                                            break;
                                                                        case obszar_waznosci.RUMIA:
                                                                            cena = 152.0;
                                                                            break;
                                                                        case obszar_waznosci.KOSAKOWO_GM:
                                                                            cena = 152.0;
                                                                            break;
                                                                        case obszar_waznosci.ZUKOWO_GM:
                                                                            cena = 152.0;
                                                                            break;
                                                                        case obszar_waznosci.SZEMUD_GM:
                                                                            cena = 152.0;
                                                                            break;
                                                                        case obszar_waznosci.WEJHEROWO_GM:
                                                                            cena = 152.0;
                                                                            break;
                                                                        case obszar_waznosci.RUMA_REDA_WEJHEROWO:
                                                                            cena = 200.0;
                                                                            break;
                                                                        case obszar_waznosci.RUMIA_WEJHEROWO_GM:
                                                                            cena = 200.0;
                                                                            break;
                                                                        case obszar_waznosci.SIEC_KOMUNIKACYJNA:
                                                                            cena = 247.0;
                                                                            break;
                                                                        case obszar_waznosci.METROPOLITALNY:
                                                                            cena = -1.0;
                                                                            break;
                                                                        case obszar_waznosci.BRAK:
                                                                            cena = -1.0;
                                                                            break;
                                                                        default:
                                                                            break;
                                                                    }
                                                                    break;
                                                                case rodzaj_linii.BRAK:
                                                                    cena = -1.0;
                                                                    break;
                                                                default:
                                                                    break;
                                                            }
                                                            break;
                                                        case okres_semestru.BRAK:
                                                            cena = -1.0;
                                                            break;
                                                        default:
                                                            break;
                                                    }
                                                    break;
                                                case rodzaj_ulgi.BRAK:
                                                    cena = -1.0;
                                                    break;
                                                default:
                                                    break;
                                            }
                                            break;
                                        case dlugosc_waznosci.BRAK:
                                            cena = -1.0;
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case typ_biletu.NA_OKAZICIELA:
                                    switch (rodzaj_Ulgi)
                                    {
                                        case rodzaj_ulgi.NORMALNY:
                                            switch (rodzaj_Linii)
                                            {
                                                case rodzaj_linii.ZWYKLE:
                                                    switch (obszar_Waznosci)
                                                    {
                                                        case obszar_waznosci.GDYNIA:
                                                            cena = 92.0;
                                                            break;
                                                        default:
                                                            break;
                                                    }
                                                    break;
                                                case rodzaj_linii.NOCNE:
                                                    switch (obszar_Waznosci)
                                                    {
                                                        case obszar_waznosci.GDYNIA:
                                                            cena = 107.0;
                                                            break;
                                                        case obszar_waznosci.SOPOT:
                                                            cena = 75.0;
                                                            break;
                                                        case obszar_waznosci.RUMIA:
                                                            cena = 75.0;
                                                            break;
                                                        case obszar_waznosci.KOSAKOWO_GM:
                                                            cena = 75.0;
                                                            break;
                                                        case obszar_waznosci.ZUKOWO_GM:
                                                            cena = 75.0;
                                                            break;
                                                        case obszar_waznosci.SZEMUD_GM:
                                                            cena = 75.0;
                                                            break;
                                                        case obszar_waznosci.WEJHEROWO_GM:
                                                            cena = 75.0;
                                                            break;
                                                        case obszar_waznosci.RUMA_REDA_WEJHEROWO:
                                                            cena = 97.0;
                                                            break;
                                                        case obszar_waznosci.RUMIA_WEJHEROWO_GM:
                                                            cena = 97.0;
                                                            break;
                                                        case obszar_waznosci.SIEC_KOMUNIKACYJNA:
                                                            cena = 117.0;
                                                            break;
                                                        case obszar_waznosci.METROPOLITALNY:
                                                            break;
                                                        case obszar_waznosci.BRAK:
                                                            cena = -1.0;
                                                            break;
                                                        default:
                                                            break;
                                                    }
                                                    break;
                                                case rodzaj_linii.BRAK:
                                                    cena = -1.0;
                                                    break;
                                                default:
                                                    break;
                                            }
                                            break;
                                        case rodzaj_ulgi.ULGOWY:
                                            cena = -1.0;
                                            break;
                                        case rodzaj_ulgi.BRAK:
                                            cena = -1.0;
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case typ_biletu.BRAK:
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case okres_biletu._30_DNIOWY:
                            switch (typ_Biletu)
                            {
                                case typ_biletu.IMIENNY:
                                    switch (dlugosc_Waznosci)
                                    {
                                        case dlugosc_waznosci.OD_PON_DO_PT:
                                            switch (rodzaj_Ulgi)
                                            {
                                                case rodzaj_ulgi.NORMALNY:
                                                    switch (rodzaj_Linii)
                                                    {
                                                        case rodzaj_linii.ZWYKLE:
                                                            switch (obszar_Waznosci)
                                                            {
                                                                case obszar_waznosci.GDYNIA:
                                                                    cena = 72.0;
                                                                    break;
                                                                default:
                                                                    break;
                                                            }
                                                            break;
                                                        case rodzaj_linii.NOCNE:
                                                            switch (obszar_Waznosci)
                                                            {
                                                                case obszar_waznosci.GDYNIA:
                                                                    cena = 86.0;
                                                                    break;
                                                                case obszar_waznosci.SOPOT:
                                                                    cena = 58.0;
                                                                    break;
                                                                case obszar_waznosci.RUMIA:
                                                                    cena = 58.0;
                                                                    break;
                                                                case obszar_waznosci.KOSAKOWO_GM:
                                                                    cena = 58.0;
                                                                    break;
                                                                case obszar_waznosci.ZUKOWO_GM:
                                                                    cena = 58.0;
                                                                    break;
                                                                case obszar_waznosci.SZEMUD_GM:
                                                                    cena = 58.0;
                                                                    break;
                                                                case obszar_waznosci.WEJHEROWO_GM:
                                                                    cena = 58.0;
                                                                    break;
                                                                case obszar_waznosci.RUMA_REDA_WEJHEROWO:
                                                                    cena = 74.0;
                                                                    break;
                                                                case obszar_waznosci.RUMIA_WEJHEROWO_GM:
                                                                    cena = 74.0;
                                                                    break;
                                                                case obszar_waznosci.SIEC_KOMUNIKACYJNA:
                                                                    cena = 96.0;
                                                                    break;
                                                                case obszar_waznosci.METROPOLITALNY:
                                                                    break;
                                                                case obszar_waznosci.BRAK:
                                                                    cena = -1.0;
                                                                    break;
                                                                default:
                                                                    break;
                                                            }
                                                            break;
                                                        case rodzaj_linii.BRAK:
                                                            cena = -1.0;
                                                            break;
                                                        default:
                                                            break;
                                                    }
                                                    break;
                                                case rodzaj_ulgi.ULGOWY:
                                                    switch (rodzaj_Linii)
                                                    {
                                                        case rodzaj_linii.ZWYKLE:
                                                            switch (obszar_Waznosci)
                                                            {
                                                                case obszar_waznosci.GDYNIA:
                                                                    cena = 36.0;
                                                                    break;
                                                                default:
                                                                    break;
                                                            }
                                                            break;
                                                        case rodzaj_linii.NOCNE:
                                                            switch (obszar_Waznosci)
                                                            {
                                                                case obszar_waznosci.GDYNIA:
                                                                    cena = 43.0;
                                                                    break;
                                                                case obszar_waznosci.SOPOT:
                                                                    cena = 29.0;
                                                                    break;
                                                                case obszar_waznosci.RUMIA:
                                                                    cena = 29.0;
                                                                    break;
                                                                case obszar_waznosci.KOSAKOWO_GM:
                                                                    cena = 29.0;
                                                                    break;
                                                                case obszar_waznosci.ZUKOWO_GM:
                                                                    cena = 29.0;
                                                                    break;
                                                                case obszar_waznosci.SZEMUD_GM:
                                                                    cena = 29.0;
                                                                    break;
                                                                case obszar_waznosci.WEJHEROWO_GM:
                                                                    cena = 29.0;
                                                                    break;
                                                                case obszar_waznosci.RUMA_REDA_WEJHEROWO:
                                                                    cena = 37.0;
                                                                    break;
                                                                case obszar_waznosci.RUMIA_WEJHEROWO_GM:
                                                                    cena = 37.0;
                                                                    break;
                                                                case obszar_waznosci.SIEC_KOMUNIKACYJNA:
                                                                    cena = 48.0;
                                                                    break;
                                                                case obszar_waznosci.METROPOLITALNY:
                                                                    cena = -1.0;
                                                                    break;
                                                                case obszar_waznosci.BRAK:
                                                                    cena = -1.0;
                                                                    break;
                                                                default:
                                                                    break;
                                                            }
                                                            break;
                                                        case rodzaj_linii.BRAK:
                                                            cena = -1.0;
                                                            break;
                                                        default:
                                                            break;
                                                    }
                                                    break;
                                                case rodzaj_ulgi.BRAK:
                                                    cena = -1.0;
                                                    break;
                                                default:
                                                    break;
                                            }
                                            break;
                                        case dlugosc_waznosci.CALY_TYDZIEN:
                                            switch (rodzaj_Ulgi)
                                            {
                                                case rodzaj_ulgi.NORMALNY:
                                                    switch (rodzaj_Linii)
                                                    {
                                                        case rodzaj_linii.ZWYKLE:
                                                            switch (obszar_Waznosci)
                                                            {
                                                                case obszar_waznosci.GDYNIA:
                                                                    cena = 82.0;
                                                                    break;
                                                                default:
                                                                    break;
                                                            }
                                                            break;
                                                        case rodzaj_linii.NOCNE:
                                                            switch (obszar_Waznosci)
                                                            {
                                                                case obszar_waznosci.GDYNIA:
                                                                    cena = 94.0;
                                                                    break;
                                                                case obszar_waznosci.SOPOT:
                                                                    cena = 64.0;
                                                                    break;
                                                                case obszar_waznosci.RUMIA:
                                                                    cena = 64.0;
                                                                    break;
                                                                case obszar_waznosci.KOSAKOWO_GM:
                                                                    cena = 64.0;
                                                                    break;
                                                                case obszar_waznosci.ZUKOWO_GM:
                                                                    cena = 64.0;
                                                                    break;
                                                                case obszar_waznosci.SZEMUD_GM:
                                                                    cena = 64.0;
                                                                    break;
                                                                case obszar_waznosci.WEJHEROWO_GM:
                                                                    cena = 64.0;
                                                                    break;
                                                                case obszar_waznosci.RUMA_REDA_WEJHEROWO:
                                                                    cena = 84.0;
                                                                    break;
                                                                case obszar_waznosci.RUMIA_WEJHEROWO_GM:
                                                                    cena = 84.0;
                                                                    break;
                                                                case obszar_waznosci.SIEC_KOMUNIKACYJNA:
                                                                    cena = 104.0;
                                                                    break;
                                                                case obszar_waznosci.METROPOLITALNY:
                                                                    break;
                                                                case obszar_waznosci.BRAK:
                                                                    cena = -1.0;
                                                                    break;
                                                                default:
                                                                    break;
                                                            }
                                                            break;
                                                        case rodzaj_linii.BRAK:
                                                            cena = -1.0;
                                                            break;
                                                        default:
                                                            break;
                                                    }
                                                    break;
                                                case rodzaj_ulgi.ULGOWY:
                                                    switch (rodzaj_Linii)
                                                    {
                                                        case rodzaj_linii.ZWYKLE:
                                                            switch (obszar_Waznosci)
                                                            {
                                                                case obszar_waznosci.GDYNIA:
                                                                    cena = 41.0;
                                                                    break;
                                                                default:
                                                                    break;
                                                            }
                                                            break;
                                                        case rodzaj_linii.NOCNE:
                                                            switch (obszar_Waznosci)
                                                            {
                                                                case obszar_waznosci.GDYNIA:
                                                                    cena = 47.0;
                                                                    break;
                                                                case obszar_waznosci.SOPOT:
                                                                    cena = 32.0;
                                                                    break;
                                                                case obszar_waznosci.RUMIA:
                                                                    cena = 32.0;
                                                                    break;
                                                                case obszar_waznosci.KOSAKOWO_GM:
                                                                    cena = 32.0;
                                                                    break;
                                                                case obszar_waznosci.ZUKOWO_GM:
                                                                    cena = 32.0;
                                                                    break;
                                                                case obszar_waznosci.SZEMUD_GM:
                                                                    cena = 32.0;
                                                                    break;
                                                                case obszar_waznosci.WEJHEROWO_GM:
                                                                    cena = 32.0;
                                                                    break;
                                                                case obszar_waznosci.RUMA_REDA_WEJHEROWO:
                                                                    cena = 42.0;
                                                                    break;
                                                                case obszar_waznosci.RUMIA_WEJHEROWO_GM:
                                                                    cena = 42.0;
                                                                    break;
                                                                case obszar_waznosci.SIEC_KOMUNIKACYJNA:
                                                                    cena = 52.0;
                                                                    break;
                                                                case obszar_waznosci.METROPOLITALNY:
                                                                    cena = -1.0;
                                                                    break;
                                                                case obszar_waznosci.BRAK:
                                                                    cena = -1.0;
                                                                    break;
                                                                default:
                                                                    break;
                                                            }
                                                            break;
                                                        case rodzaj_linii.BRAK:
                                                            cena = -1.0;
                                                            break;
                                                        default:
                                                            break;
                                                    }
                                                    break;
                                                case rodzaj_ulgi.BRAK:
                                                    cena = -1.0;
                                                    break;
                                                default:
                                                    break;
                                            }
                                            break;
                                        case dlugosc_waznosci._4_MIESIECZNY:
                                            switch (rodzaj_Ulgi)
                                            {
                                                case rodzaj_ulgi.NORMALNY:
                                                    cena = -1.0;
                                                    break;
                                                case rodzaj_ulgi.ULGOWY:
                                                    switch (okres_Semestru)
                                                    {
                                                        case okres_semestru.LETNI_4_MIES:
                                                            switch (rodzaj_Linii)
                                                            {
                                                                case rodzaj_linii.ZWYKLE:
                                                                    switch (obszar_Waznosci)
                                                                    {
                                                                        case obszar_waznosci.GDYNIA:
                                                                            cena = 156.0;
                                                                            break;
                                                                        default:
                                                                            break;
                                                                    }
                                                                    break;
                                                                case rodzaj_linii.NOCNE:
                                                                    switch (obszar_Waznosci)
                                                                    {
                                                                        case obszar_waznosci.GDYNIA:
                                                                            cena = 179.0;
                                                                            break;
                                                                        case obszar_waznosci.SOPOT:
                                                                            cena = 122.0;
                                                                            break;
                                                                        case obszar_waznosci.RUMIA:
                                                                            cena = 122.0;
                                                                            break;
                                                                        case obszar_waznosci.KOSAKOWO_GM:
                                                                            cena = 122.0;
                                                                            break;
                                                                        case obszar_waznosci.ZUKOWO_GM:
                                                                            cena = 122.0;
                                                                            break;
                                                                        case obszar_waznosci.SZEMUD_GM:
                                                                            cena = 122.0;
                                                                            break;
                                                                        case obszar_waznosci.WEJHEROWO_GM:
                                                                            cena = 122.0;
                                                                            break;
                                                                        case obszar_waznosci.RUMA_REDA_WEJHEROWO:
                                                                            cena = 160.0;
                                                                            break;
                                                                        case obszar_waznosci.RUMIA_WEJHEROWO_GM:
                                                                            cena = 160.0;
                                                                            break;
                                                                        case obszar_waznosci.SIEC_KOMUNIKACYJNA:
                                                                            cena = 198.0;
                                                                            break;
                                                                        case obszar_waznosci.METROPOLITALNY:
                                                                            cena = -1.0;
                                                                            break;
                                                                        case obszar_waznosci.BRAK:
                                                                            cena = -1.0;
                                                                            break;
                                                                        default:
                                                                            break;
                                                                    }
                                                                    break;
                                                                case rodzaj_linii.BRAK:
                                                                    cena = -1.0;
                                                                    break;
                                                                default:
                                                                    break;
                                                            }
                                                            break;
                                                        case okres_semestru.LETNI_5_MIES:
                                                            switch (rodzaj_Linii)
                                                            {
                                                                case rodzaj_linii.ZWYKLE:
                                                                    switch (obszar_Waznosci)
                                                                    {
                                                                        case obszar_waznosci.GDYNIA:
                                                                            cena = 195.0;
                                                                            break;
                                                                        default:
                                                                            break;
                                                                    }
                                                                    break;
                                                                case rodzaj_linii.NOCNE:
                                                                    switch (obszar_Waznosci)
                                                                    {
                                                                        case obszar_waznosci.GDYNIA:
                                                                            cena = 223.0;
                                                                            break;
                                                                        case obszar_waznosci.SOPOT:
                                                                            cena = 152.0;
                                                                            break;
                                                                        case obszar_waznosci.RUMIA:
                                                                            cena = 152.0;
                                                                            break;
                                                                        case obszar_waznosci.KOSAKOWO_GM:
                                                                            cena = 152.0;
                                                                            break;
                                                                        case obszar_waznosci.ZUKOWO_GM:
                                                                            cena = 152.0;
                                                                            break;
                                                                        case obszar_waznosci.SZEMUD_GM:
                                                                            cena = 152.0;
                                                                            break;
                                                                        case obszar_waznosci.WEJHEROWO_GM:
                                                                            cena = 152.0;
                                                                            break;
                                                                        case obszar_waznosci.RUMA_REDA_WEJHEROWO:
                                                                            cena = 200.0;
                                                                            break;
                                                                        case obszar_waznosci.RUMIA_WEJHEROWO_GM:
                                                                            cena = 200.0;
                                                                            break;
                                                                        case obszar_waznosci.SIEC_KOMUNIKACYJNA:
                                                                            cena = 247.0;
                                                                            break;
                                                                        case obszar_waznosci.METROPOLITALNY:
                                                                            cena = -1.0;
                                                                            break;
                                                                        case obszar_waznosci.BRAK:
                                                                            cena = -1.0;
                                                                            break;
                                                                        default:
                                                                            break;
                                                                    }
                                                                    break;
                                                                case rodzaj_linii.BRAK:
                                                                    cena = -1.0;
                                                                    break;
                                                                default:
                                                                    break;
                                                            }
                                                            break;
                                                        case okres_semestru.ZIMOWY_4_MIES:
                                                            switch (rodzaj_Linii)
                                                            {
                                                                case rodzaj_linii.ZWYKLE:
                                                                    switch (obszar_Waznosci)
                                                                    {
                                                                        case obszar_waznosci.GDYNIA:
                                                                            cena = 156.0;
                                                                            break;
                                                                        default:
                                                                            break;
                                                                    }
                                                                    break;
                                                                case rodzaj_linii.NOCNE:
                                                                    switch (obszar_Waznosci)
                                                                    {
                                                                        case obszar_waznosci.GDYNIA:
                                                                            cena = 179.0;
                                                                            break;
                                                                        case obszar_waznosci.SOPOT:
                                                                            cena = 122.0;
                                                                            break;
                                                                        case obszar_waznosci.RUMIA:
                                                                            cena = 122.0;
                                                                            break;
                                                                        case obszar_waznosci.KOSAKOWO_GM:
                                                                            cena = 122.0;
                                                                            break;
                                                                        case obszar_waznosci.ZUKOWO_GM:
                                                                            cena = 122.0;
                                                                            break;
                                                                        case obszar_waznosci.SZEMUD_GM:
                                                                            cena = 122.0;
                                                                            break;
                                                                        case obszar_waznosci.WEJHEROWO_GM:
                                                                            cena = 122.0;
                                                                            break;
                                                                        case obszar_waznosci.RUMA_REDA_WEJHEROWO:
                                                                            cena = 160.0;
                                                                            break;
                                                                        case obszar_waznosci.RUMIA_WEJHEROWO_GM:
                                                                            cena = 160.0;
                                                                            break;
                                                                        case obszar_waznosci.SIEC_KOMUNIKACYJNA:
                                                                            cena = 198.0;
                                                                            break;
                                                                        case obszar_waznosci.METROPOLITALNY:
                                                                            cena = -1.0;
                                                                            break;
                                                                        case obszar_waznosci.BRAK:
                                                                            cena = -1.0;
                                                                            break;
                                                                        default:
                                                                            break;
                                                                    }
                                                                    break;
                                                                case rodzaj_linii.BRAK:
                                                                    cena = -1.0;
                                                                    break;
                                                                default:
                                                                    break;
                                                            }
                                                            break;
                                                        case okres_semestru.ZIMOWY_5_MIES:
                                                            switch (rodzaj_Linii)
                                                            {
                                                                case rodzaj_linii.ZWYKLE:
                                                                    switch (obszar_Waznosci)
                                                                    {
                                                                        case obszar_waznosci.GDYNIA:
                                                                            cena = 195.0;
                                                                            break;
                                                                        default:
                                                                            break;
                                                                    }
                                                                    break;
                                                                case rodzaj_linii.NOCNE:
                                                                    switch (obszar_Waznosci)
                                                                    {
                                                                        case obszar_waznosci.GDYNIA:
                                                                            cena = 223.0;
                                                                            break;
                                                                        case obszar_waznosci.SOPOT:
                                                                            cena = 152.0;
                                                                            break;
                                                                        case obszar_waznosci.RUMIA:
                                                                            cena = 152.0;
                                                                            break;
                                                                        case obszar_waznosci.KOSAKOWO_GM:
                                                                            cena = 152.0;
                                                                            break;
                                                                        case obszar_waznosci.ZUKOWO_GM:
                                                                            cena = 152.0;
                                                                            break;
                                                                        case obszar_waznosci.SZEMUD_GM:
                                                                            cena = 152.0;
                                                                            break;
                                                                        case obszar_waznosci.WEJHEROWO_GM:
                                                                            cena = 152.0;
                                                                            break;
                                                                        case obszar_waznosci.RUMA_REDA_WEJHEROWO:
                                                                            cena = 200.0;
                                                                            break;
                                                                        case obszar_waznosci.RUMIA_WEJHEROWO_GM:
                                                                            cena = 200.0;
                                                                            break;
                                                                        case obszar_waznosci.SIEC_KOMUNIKACYJNA:
                                                                            cena = 247.0;
                                                                            break;
                                                                        case obszar_waznosci.METROPOLITALNY:
                                                                            cena = -1.0;
                                                                            break;
                                                                        case obszar_waznosci.BRAK:
                                                                            cena = -1.0;
                                                                            break;
                                                                        default:
                                                                            break;
                                                                    }
                                                                    break;
                                                                case rodzaj_linii.BRAK:
                                                                    cena = -1.0;
                                                                    break;
                                                                default:
                                                                    break;
                                                            }
                                                            break;
                                                        case okres_semestru.BRAK:
                                                            cena = -1.0;
                                                            break;
                                                        default:
                                                            break;
                                                    }
                                                    break;
                                                case rodzaj_ulgi.BRAK:
                                                    cena = -1.0;
                                                    break;
                                                default:
                                                    break;
                                            }
                                            break;
                                        case dlugosc_waznosci._5_MIESIECZNY:
                                            switch (rodzaj_Ulgi)
                                            {
                                                case rodzaj_ulgi.NORMALNY:
                                                    cena = -1.0;
                                                    break;
                                                case rodzaj_ulgi.ULGOWY:
                                                    switch (okres_Semestru)
                                                    {
                                                        case okres_semestru.LETNI_4_MIES:
                                                            switch (rodzaj_Linii)
                                                            {
                                                                case rodzaj_linii.ZWYKLE:
                                                                    switch (obszar_Waznosci)
                                                                    {
                                                                        case obszar_waznosci.GDYNIA:
                                                                            cena = 156.0;
                                                                            break;
                                                                        default:
                                                                            break;
                                                                    }
                                                                    break;
                                                                case rodzaj_linii.NOCNE:
                                                                    switch (obszar_Waznosci)
                                                                    {
                                                                        case obszar_waznosci.GDYNIA:
                                                                            cena = 179.0;
                                                                            break;
                                                                        case obszar_waznosci.SOPOT:
                                                                            cena = 122.0;
                                                                            break;
                                                                        case obszar_waznosci.RUMIA:
                                                                            cena = 122.0;
                                                                            break;
                                                                        case obszar_waznosci.KOSAKOWO_GM:
                                                                            cena = 122.0;
                                                                            break;
                                                                        case obszar_waznosci.ZUKOWO_GM:
                                                                            cena = 122.0;
                                                                            break;
                                                                        case obszar_waznosci.SZEMUD_GM:
                                                                            cena = 122.0;
                                                                            break;
                                                                        case obszar_waznosci.WEJHEROWO_GM:
                                                                            cena = 122.0;
                                                                            break;
                                                                        case obszar_waznosci.RUMA_REDA_WEJHEROWO:
                                                                            cena = 160.0;
                                                                            break;
                                                                        case obszar_waznosci.RUMIA_WEJHEROWO_GM:
                                                                            cena = 160.0;
                                                                            break;
                                                                        case obszar_waznosci.SIEC_KOMUNIKACYJNA:
                                                                            cena = 198.0;
                                                                            break;
                                                                        case obszar_waznosci.METROPOLITALNY:
                                                                            cena = -1.0;
                                                                            break;
                                                                        case obszar_waznosci.BRAK:
                                                                            cena = -1.0;
                                                                            break;
                                                                        default:
                                                                            break;
                                                                    }
                                                                    break;
                                                                case rodzaj_linii.BRAK:
                                                                    cena = -1.0;
                                                                    break;
                                                                default:
                                                                    break;
                                                            }
                                                            break;
                                                        case okres_semestru.LETNI_5_MIES:
                                                            switch (rodzaj_Linii)
                                                            {
                                                                case rodzaj_linii.ZWYKLE:
                                                                    switch (obszar_Waznosci)
                                                                    {
                                                                        case obszar_waznosci.GDYNIA:
                                                                            cena = 195.0;
                                                                            break;
                                                                        default:
                                                                            break;
                                                                    }
                                                                    break;
                                                                case rodzaj_linii.NOCNE:
                                                                    switch (obszar_Waznosci)
                                                                    {
                                                                        case obszar_waznosci.GDYNIA:
                                                                            cena = 223.0;
                                                                            break;
                                                                        case obszar_waznosci.SOPOT:
                                                                            cena = 152.0;
                                                                            break;
                                                                        case obszar_waznosci.RUMIA:
                                                                            cena = 152.0;
                                                                            break;
                                                                        case obszar_waznosci.KOSAKOWO_GM:
                                                                            cena = 152.0;
                                                                            break;
                                                                        case obszar_waznosci.ZUKOWO_GM:
                                                                            cena = 152.0;
                                                                            break;
                                                                        case obszar_waznosci.SZEMUD_GM:
                                                                            cena = 152.0;
                                                                            break;
                                                                        case obszar_waznosci.WEJHEROWO_GM:
                                                                            cena = 152.0;
                                                                            break;
                                                                        case obszar_waznosci.RUMA_REDA_WEJHEROWO:
                                                                            cena = 200.0;
                                                                            break;
                                                                        case obszar_waznosci.RUMIA_WEJHEROWO_GM:
                                                                            cena = 200.0;
                                                                            break;
                                                                        case obszar_waznosci.SIEC_KOMUNIKACYJNA:
                                                                            cena = 247.0;
                                                                            break;
                                                                        case obszar_waznosci.METROPOLITALNY:
                                                                            cena = -1.0;
                                                                            break;
                                                                        case obszar_waznosci.BRAK:
                                                                            cena = -1.0;
                                                                            break;
                                                                        default:
                                                                            break;
                                                                    }
                                                                    break;
                                                                case rodzaj_linii.BRAK:
                                                                    cena = -1.0;
                                                                    break;
                                                                default:
                                                                    break;
                                                            }
                                                            break;
                                                        case okres_semestru.ZIMOWY_4_MIES:
                                                            switch (rodzaj_Linii)
                                                            {
                                                                case rodzaj_linii.ZWYKLE:
                                                                    switch (obszar_Waznosci)
                                                                    {
                                                                        case obszar_waznosci.GDYNIA:
                                                                            cena = 156.0;
                                                                            break;
                                                                        default:
                                                                            break;
                                                                    }
                                                                    break;
                                                                case rodzaj_linii.NOCNE:
                                                                    switch (obszar_Waznosci)
                                                                    {
                                                                        case obszar_waznosci.GDYNIA:
                                                                            cena = 179.0;
                                                                            break;
                                                                        case obszar_waznosci.SOPOT:
                                                                            cena = 122.0;
                                                                            break;
                                                                        case obszar_waznosci.RUMIA:
                                                                            cena = 122.0;
                                                                            break;
                                                                        case obszar_waznosci.KOSAKOWO_GM:
                                                                            cena = 122.0;
                                                                            break;
                                                                        case obszar_waznosci.ZUKOWO_GM:
                                                                            cena = 122.0;
                                                                            break;
                                                                        case obszar_waznosci.SZEMUD_GM:
                                                                            cena = 122.0;
                                                                            break;
                                                                        case obszar_waznosci.WEJHEROWO_GM:
                                                                            cena = 122.0;
                                                                            break;
                                                                        case obszar_waznosci.RUMA_REDA_WEJHEROWO:
                                                                            cena = 160.0;
                                                                            break;
                                                                        case obszar_waznosci.RUMIA_WEJHEROWO_GM:
                                                                            cena = 160.0;
                                                                            break;
                                                                        case obszar_waznosci.SIEC_KOMUNIKACYJNA:
                                                                            cena = 198.0;
                                                                            break;
                                                                        case obszar_waznosci.METROPOLITALNY:
                                                                            cena = -1.0;
                                                                            break;
                                                                        case obszar_waznosci.BRAK:
                                                                            cena = -1.0;
                                                                            break;
                                                                        default:
                                                                            break;
                                                                    }
                                                                    break;
                                                                case rodzaj_linii.BRAK:
                                                                    cena = -1.0;
                                                                    break;
                                                                default:
                                                                    break;
                                                            }
                                                            break;
                                                        case okres_semestru.ZIMOWY_5_MIES:
                                                            switch (rodzaj_Linii)
                                                            {
                                                                case rodzaj_linii.ZWYKLE:
                                                                    switch (obszar_Waznosci)
                                                                    {
                                                                        case obszar_waznosci.GDYNIA:
                                                                            cena = 195.0;
                                                                            break;
                                                                        default:
                                                                            break;
                                                                    }
                                                                    break;
                                                                case rodzaj_linii.NOCNE:
                                                                    switch (obszar_Waznosci)
                                                                    {
                                                                        case obszar_waznosci.GDYNIA:
                                                                            cena = 223.0;
                                                                            break;
                                                                        case obszar_waznosci.SOPOT:
                                                                            cena = 152.0;
                                                                            break;
                                                                        case obszar_waznosci.RUMIA:
                                                                            cena = 152.0;
                                                                            break;
                                                                        case obszar_waznosci.KOSAKOWO_GM:
                                                                            cena = 152.0;
                                                                            break;
                                                                        case obszar_waznosci.ZUKOWO_GM:
                                                                            cena = 152.0;
                                                                            break;
                                                                        case obszar_waznosci.SZEMUD_GM:
                                                                            cena = 152.0;
                                                                            break;
                                                                        case obszar_waznosci.WEJHEROWO_GM:
                                                                            cena = 152.0;
                                                                            break;
                                                                        case obszar_waznosci.RUMA_REDA_WEJHEROWO:
                                                                            cena = 200.0;
                                                                            break;
                                                                        case obszar_waznosci.RUMIA_WEJHEROWO_GM:
                                                                            cena = 200.0;
                                                                            break;
                                                                        case obszar_waznosci.SIEC_KOMUNIKACYJNA:
                                                                            cena = 247.0;
                                                                            break;
                                                                        case obszar_waznosci.METROPOLITALNY:
                                                                            cena = -1.0;
                                                                            break;
                                                                        case obszar_waznosci.BRAK:
                                                                            cena = -1.0;
                                                                            break;
                                                                        default:
                                                                            break;
                                                                    }
                                                                    break;
                                                                case rodzaj_linii.BRAK:
                                                                    cena = -1.0;
                                                                    break;
                                                                default:
                                                                    break;
                                                            }
                                                            break;
                                                        case okres_semestru.BRAK:
                                                            cena = -1.0;
                                                            break;
                                                        default:
                                                            break;
                                                    }
                                                    break;
                                                case rodzaj_ulgi.BRAK:
                                                    cena = -1.0;
                                                    break;
                                                default:
                                                    break;
                                            }
                                            break;
                                        case dlugosc_waznosci.BRAK:
                                            cena = -1.0;
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case typ_biletu.NA_OKAZICIELA:
                                    switch (rodzaj_Ulgi)
                                    {
                                        case rodzaj_ulgi.NORMALNY:
                                            switch (rodzaj_Linii)
                                            {
                                                case rodzaj_linii.ZWYKLE:
                                                    switch (obszar_Waznosci)
                                                    {
                                                        case obszar_waznosci.GDYNIA:
                                                            cena = 92.0;
                                                            break;
                                                        default:
                                                            break;
                                                    }
                                                    break;
                                                case rodzaj_linii.NOCNE:
                                                    switch (obszar_Waznosci)
                                                    {
                                                        case obszar_waznosci.GDYNIA:
                                                            cena = 107.0;
                                                            break;
                                                        case obszar_waznosci.SOPOT:
                                                            cena = 75.0;
                                                            break;
                                                        case obszar_waznosci.RUMIA:
                                                            cena = 75.0;
                                                            break;
                                                        case obszar_waznosci.KOSAKOWO_GM:
                                                            cena = 75.0;
                                                            break;
                                                        case obszar_waznosci.ZUKOWO_GM:
                                                            cena = 75.0;
                                                            break;
                                                        case obszar_waznosci.SZEMUD_GM:
                                                            cena = 75.0;
                                                            break;
                                                        case obszar_waznosci.WEJHEROWO_GM:
                                                            cena = 75.0;
                                                            break;
                                                        case obszar_waznosci.RUMA_REDA_WEJHEROWO:
                                                            cena = 97.0;
                                                            break;
                                                        case obszar_waznosci.RUMIA_WEJHEROWO_GM:
                                                            cena = 97.0;
                                                            break;
                                                        case obszar_waznosci.SIEC_KOMUNIKACYJNA:
                                                            cena = 117.0;
                                                            break;
                                                        case obszar_waznosci.METROPOLITALNY:
                                                            break;
                                                        case obszar_waznosci.BRAK:
                                                            cena = -1.0;
                                                            break;
                                                        default:
                                                            break;
                                                    }
                                                    break;
                                                case rodzaj_linii.BRAK:
                                                    cena = -1.0;
                                                    break;
                                                default:
                                                    break;
                                            }
                                            break;
                                        case rodzaj_ulgi.ULGOWY:
                                            cena = -1.0;
                                            break;
                                        case rodzaj_ulgi.BRAK:
                                            cena = -1.0;
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case typ_biletu.BRAK:
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case okres_biletu.SEMESTRALNY:
                            break;
                        case okres_biletu.BRAK:
                            break;
                        default:
                            break;
                    }
                    break;
                case przewoznik.MZKG:
                    break;
                case przewoznik.BRAK:
                    break;
                default:
                    break;
            }
            return cena;
        } 
    };
}
