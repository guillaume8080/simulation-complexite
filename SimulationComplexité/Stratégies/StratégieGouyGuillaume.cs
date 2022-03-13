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

            if (complexitéAccidentelleActuelle + scoreProduitActuel >= 1056)
            {
                return this.pondreUneDerniereFeature();
            }
            
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
                
                return Convert.ToUInt32(investissemntQualite);
        }

        public uint admettreCroissanceEntropie(int iteration)
        {
            // DETAIL RAISONNEMENT :
            // Cet algo a pour but de stimuler l 'investissement produit en relativisant l'investissement qualité
            // Quelsques constantes:
            // nb d'itéarations myens : 144
            // Point de non retour  = 1061
            //Limite de complexité accidentelle = 1O92 = 1*3 
            
            // Pour appeler cet algo , on admet atteindre 1/3 de la LCA sur 1/6 de la duree de vie du projet
            
            
            
            
            return 0;
        }
        // cette methode est appellee lorsque le projet admet un point de non retour ~= 1056
        public uint pondreUneDerniereFeature()
        {
            return 0;
        }

   
        
        
        
        
    }
    
}
