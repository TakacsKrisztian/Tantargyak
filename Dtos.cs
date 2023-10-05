namespace Tantargyak
{
    
            public record TantargyDto(Guid Azon, int Jegy, string Leiras, string Letrejott);
            public record TantargyLetrehozasDto(int Jegy, string Leiras);
            public record TantargyValtozasDto(int Jegy, string Leiras);
            public record TantargyTorlesDto(int Jegy, string Leiras);
        
    }