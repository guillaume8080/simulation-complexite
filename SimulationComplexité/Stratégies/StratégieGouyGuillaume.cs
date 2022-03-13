using SimulationComplexité.Simulation;

namespace SimulationComplexité.Stratégies
{
    internal class VotreStratégie : IStratégieQualité
    {
        /// <inheritdoc />

        private int _iteration = 0;
        private int _sommeInvestissementProduit = 0;
        private int _sommeInvestissementQualite = 0;
        
        
        public uint MontantInvestiEnQualité(uint valeurProduiteBrute, uint complexitéAccidentelleActuelle, uint scoreProduitActuel, ushort coutDUnDé)
        {
            _iteration ++;
            uint investissementQualite = this.soustractionInvestissementProduitInvestQualitéNull(valeurProduiteBrute, _iteration);
            
            return investissementQualite;
        }
        //partie deroulee à ynov -
        // Cette strategie sert de base à toutes mes observations : définition de lois et constantes
        // Cette strategie 
        public uint soustractionInvestissementProduitInvestQualitéNull(uint valeurProduiteBrute ,int iterationActuelle)
        {

            double investissemntQualite = 0;
            double invesissementProduit = 0;
            
            // maniere d investir --> 
            float valeurProduiteParDeux =  (float)valeurProduiteBrute / 2;

            if (valeurProduiteParDeux % 2 == 0)
            {
                 investissemntQualite = Math.Truncate(valeurProduiteParDeux);
                 invesissementProduit = Math.Round(valeurProduiteParDeux);

                 _sommeInvestissementProduit = _sommeInvestissementProduit + (int)invesissementProduit;
                 _sommeInvestissementQualite = _sommeInvestissementQualite + (int)investissemntQualite;


            }

            if ((valeurProduiteParDeux % 2 != 0)  && (_iteration == 1) )
            {
                investissemntQualite = Math.Truncate(valeurProduiteParDeux);
                // observer comporterment lorque x = .5
                invesissementProduit = Math.Round(valeurProduiteParDeux, MidpointRounding.AwayFromZero);
                
                _sommeInvestissementProduit = _sommeInvestissementProduit + (int)invesissementProduit;
                _sommeInvestissementQualite = _sommeInvestissementQualite + (int)investissemntQualite;
            }

            
                if ((valeurProduiteParDeux % 2 != 0) && (_iteration > 1))
                {
                    if (_sommeInvestissementProduit > _sommeInvestissementQualite)
                    {
                        invesissementProduit = Math.Truncate(valeurProduiteParDeux);
                        // observer comporterment lorque x = .5
                        investissemntQualite = Math.Round(valeurProduiteParDeux, MidpointRounding.AwayFromZero);

                        _sommeInvestissementProduit = _sommeInvestissementProduit + (int) invesissementProduit;
                        _sommeInvestissementQualite = _sommeInvestissementQualite + (int) investissemntQualite;
                    }
                    else if (_sommeInvestissementQualite > _sommeInvestissementProduit)
                    {
                        investissemntQualite = Math.Truncate(valeurProduiteParDeux);
                        invesissementProduit = Math.Round(valeurProduiteParDeux, MidpointRounding.AwayFromZero);

                        _sommeInvestissementProduit = _sommeInvestissementProduit + (int) invesissementProduit;
                        _sommeInvestissementQualite = _sommeInvestissementQualite + (int) investissemntQualite;
                    }
                    
                    else if (_sommeInvestissementQualite == _sommeInvestissementProduit)
                    {
                        investissemntQualite = Math.Truncate(valeurProduiteParDeux);
                        invesissementProduit = Math.Round(valeurProduiteParDeux, MidpointRounding.AwayFromZero);

                        _sommeInvestissementProduit = _sommeInvestissementProduit + (int) invesissementProduit;
                        _sommeInvestissementQualite = _sommeInvestissementQualite + (int) investissemntQualite;
                    }
                }

                if (_iteration > 130)
                {
                    return Convert.ToUInt32(investissemntQualite);
                }
            return Convert.ToUInt32(investissemntQualite);
        }

   
        
        
        
        
    }
    
}
