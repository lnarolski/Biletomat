namespace definicje_zmiennych
{
    public enum rodzaj_biletu {
        BILET_JEDNORAZOWY,
        BILET_JEDNORAZOWY_METROPOLITARNY,
        BILET_OKRESOWY,
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
        BRAK,
    }

    public static class status_biletomatu
    {
        public static status status_zakupu;
        public static wybrana_platnosc rodzaj_platnosci;

        public static void wyczysc()
        {
            status_zakupu = status.BRAK;
            rodzaj_platnosci = wybrana_platnosc.BRAK;
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
        }

        public static int liczba_biletow()
        {
            return bilet1_normalny + bilet1_ulgowy + bilet2_normalny + bilet2_ulgowy + bilet3_normalny + bilet3_ulgowy + bilet4_normalny + bilet4_ulgowy;
        }
    }
}
