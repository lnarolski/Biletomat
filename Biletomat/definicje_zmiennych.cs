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
