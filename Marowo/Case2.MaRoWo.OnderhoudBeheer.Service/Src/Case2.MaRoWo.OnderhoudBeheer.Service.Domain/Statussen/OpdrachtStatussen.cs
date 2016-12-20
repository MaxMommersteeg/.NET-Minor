namespace Case2.MaRoWo.OnderhoudBeheer.Service.Domain.Statussen
{
    public static class OpdrachtStatussen
    {
        /// <summary>
        /// Aangemeld
        /// </summary>
        /// <returns>OpdrachtStatus</returns>
        public static OpdrachtStatus Aangemeld()
        {
            return new OpdrachtStatus(10, "Aangemeld");
        }

        /// <summary>
        /// Klaargemeld
        /// </summary>
        /// <returns>OpdrachtStatus</returns>
        public static OpdrachtStatus Klaargemeld()
        {
            return new OpdrachtStatus(20, "Klaar gemeld");
        }

        /// <summary>
        /// Afgemeld
        /// </summary>
        /// <returns>OpdrachtStatus</returns>
        public static OpdrachtStatus Afgemeld()
        {
            return new OpdrachtStatus(30, "Afgemeld");
        }

        /// <summary>
        /// Afgehandeld
        /// </summary>
        /// <returns>OpdrachtStatus</returns>
        public static OpdrachtStatus Afgehandeld()
        {
            return new OpdrachtStatus(100, "Afgehandeld");
        }
    }
}
