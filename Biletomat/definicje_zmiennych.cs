namespace definicje_zmiennych
{
    class bilety_jednorazowe
    {
        public int bilet1_normalny;
        public int bilet1_ulgowy;
        public int bilet2_normalny;
        public int bilet2_ulgowy;
        public int bilet3_normalny;
        public int bilet3_ulgowy;
        public int bilet4_normalny;
        public int bilet4_ulgowy;

        public bilety_jednorazowe()
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

        public void czysc_ilosc()
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
    }
}
