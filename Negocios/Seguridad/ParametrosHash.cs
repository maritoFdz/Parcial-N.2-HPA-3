namespace Negocios.Seguridad
{
    /// <summary>Parámetros compartidos del algoritmo PBKDF2-SHA256.</summary>
    internal static class ParametrosHash
    {
        public const string Prefijo = "PBKDF2";
        public const int TamanoSalt = 16;     // bytes
        public const int TamanoHash = 32;     // bytes
        public const int Iteraciones = 100000;
    }
}