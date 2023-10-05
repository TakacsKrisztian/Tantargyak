using Tantargyak.Modell;

namespace Tantargyak
{
    public static class Bovitmeny
    {
            public static TantargyDto AsDto(this Tantargy tantargy)
            {
                return new TantargyDto(tantargy.Azon, tantargy.Jegy, tantargy.Leiras, tantargy.Letrejott);
            }
    }
}