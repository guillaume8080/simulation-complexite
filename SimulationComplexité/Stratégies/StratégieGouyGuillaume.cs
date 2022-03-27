using SimulationComplexité.Simulation;

namespace SimulationComplexité.Stratégies
{
    internal class VotreStratégie : IStratégieQualité
    {
        /// <inheritdoc />

        private int _iteration = 0;
        private int _sommeInvestissementProduit = 0;
        private int _sommeInvestissementQualite = 0;
        // ce booleen permet de la ralentir la courbe de la croissance de la comlexité accidentelle
        private bool _perdreEnQualite;
        
        
        public uint MontantInvestiEnQualité(uint valeurProduiteBrute, uint complexitéAccidentelleActuelle, uint scoreProduitActuel, ushort coutDUnDé)
        {
            if (_iteration == 0)
            {
                _perdreEnQualite = false;
                
            }
            _iteration ++;
            uint investissementQualite = this.soustractionInvestissementProduitInvestQualitéNull(valeurProduiteBrute, _iteration , complexitéAccidentelleActuelle);

            if (valeurProduiteBrute > 4)
            {
                investissementQualite =
                    this.admettreCroissanceComplexiteAccidentellePhaseAscendate(investissementQualite,ref _perdreEnQualite);
   
            }
             
            //TODO : seule a determiner: Point de non retour
             /*if (complexitéAccidentelleActuelle + scoreProduitActuel >= 1020)
            {
                return this.pondreUneDerniereFeature();
            }
            */
            return investissementQualite;
        }
        //partie deroulee à ynov -
        // Cette strategie sert de base à toutes mes observations : définition de lois et constantes
        // Cette strategie 
        public uint soustractionInvestissementProduitInvestQualitéNull(uint valeurProduiteBrute ,int iterationActuelle , uint complexitéAccidentelleActuelle )
        {

            double investissemntQualite = 0;
            double invesissementProduit = 0;
            
            // maniere d investir --> 
            float valeurProduiteParDeux =  (float)valeurProduiteBrute / 2;
            float modulo = valeurProduiteParDeux % 2;

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
                    if ((_sommeInvestissementProduit > _sommeInvestissementQualite) && complexitéAccidentelleActuelle > 0)
                    {
                        
                        invesissementProduit = Math.Truncate(valeurProduiteParDeux);
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

        public uint admettreCroissanceComplexiteAccidentellePhaseAscendate( uint investissementQualité ,ref bool unSurDeux)
        {
            // DETAIL RAISONNEMENT :
            // Cet algo a pour but de stimuler l 'investissement produit en relativisant l'investissement qualité
          
            if (unSurDeux)
            {
                investissementQualité--;
                unSurDeux = false;
            }
            else if (!unSurDeux)
            {
               
                unSurDeux = true;
            }
            
            
            
            return investissementQualité;
        }
        // cette methode est appellee lorsque le projet admet un point de non retour ~= 1056
        public uint pondreUneDerniereFeature()
        {
            return 0;
        }

   
        
        
        
        
    }
    
}
