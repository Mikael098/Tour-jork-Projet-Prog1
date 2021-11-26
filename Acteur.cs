using System;
namespace Tour_jork_Clean
{
    class Acteur
    {    
        public string Nom { get; set; }
        public string Description { get; set; }
        public double MaxHp { get; set; }
        public double Hp { get; set; }
        public double MaxArmure { get; set; }
        public double Armure { get; set; }
        public int RegenArmure { get; set; }
        public int Agilite { get; set; }
        public double Dommage { get; set; }
        public double TauxCritique { get; set; }
        
        public Acteur (string nom, double maxHp, double maxArmure, int regenArmure, int agilite, double dommage, string description)
        {
            this.Nom=nom;
            this.MaxHp=maxHp;
            this.Hp=maxHp;
            this.MaxArmure=maxArmure;
            this.Armure=maxArmure;
            this.RegenArmure=regenArmure;
            this.Agilite=agilite;
            this.Dommage=dommage;
            this.Description=description;
            this.TauxCritique = Agilite/2;
        }

        public void Attaquer( Acteur defendeur)  
        {
            int cent =0;
                    
            Random random =new Random();
            cent = random.Next (101);

            if(cent > this.TauxCritique)
            {
                defendeur.Defendre(this.Dommage);
                this.Dommage =this.Dommage*1.5;
                Console.WriteLine($"{this.Nom} a fait {this.Dommage} à {defendeur.Nom}");
            }

            else if(cent < defendeur.Agilite)
            {
                Console.WriteLine($"{this.Nom} a fait aucun dommmages à {defendeur.Nom}");
            }

            else
            {
                defendeur.Defendre(this.Dommage);
                Console.WriteLine($"{this.Nom} a fait {this.Dommage} à {defendeur.Nom}");
            }
        }

        public void Defendre(double Dommage)
        {
            //defendeur.Defendre();
            this.Armure = this.Armure-Dommage;
            if(this.Armure >0)
            {
                this.Armure += this.RegenArmure;
            }

            if(this.Armure <=0)
            {
                this.Hp += this.Armure;
                this.Armure =0;                      
                this.Armure += this.RegenArmure;
            }
        } 

        public bool estVivant()
        {
            bool vivant =false;
            if(this.Hp >0)
            {
                vivant =true;
            }
            else
            {
                vivant =false;
            }
            return vivant;
        }
        
        public void AfficherEtat(Acteur defendeur)
        {
            Console.WriteLine($"Vie de l'attaquant : {this.Hp}");
            Console.WriteLine($"Armure de l'attaquant : {this.Armure}");
            //defendeur.Defendre();
            Console.WriteLine($"Vie du défenseur : {defendeur.Hp}");      //Enemy
            Console.WriteLine($"Armure du défenseur : {defendeur.Armure}");
        }
    }
}