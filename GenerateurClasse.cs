using System.IO;
using System;
namespace Tour_jork_Clean
{
    class Utilitaire
    {    
        int guerrier =0;
        int magicien =0;
        int voleur =0;

        string[] Questions = new string[4];
        Acteur[] Classes = new Acteur[3];

        public void constructeur()
        {
            int compteurQ =0;
            string texteQ ="";

            int compteurC =0;
            string texteC ="";

            StreamReader lecteur = new StreamReader("Question.txt");
            while(!lecteur.EndOfStream)
            {
                texteQ=lecteur.ReadLine();
                Questions[compteurQ]= texteQ;
                //Console.WriteLine(Questions[compteurQ]); 
                compteurQ ++; 
            }

            StreamReader lecteurDeux = new StreamReader("classes.txt");
            while(!lecteurDeux.EndOfStream)
            {
                texteC=lecteurDeux.ReadLine();
                Classes[compteurC] = DecoderClasse(texteC.Split(';'));

                //Classes[compteurC]= texteC;
                //Console.WriteLine(Classes[compteurC]);
                compteurC ++; 
            }
        }

        private void DecoderClasse(Acteur[] Classes)
        {
            
            string[0] Classes =nom;
            double[1] Classes =hp;
            double[2] Classes =maxHp;
            double[3] Classes =armure;
            double[4] Classes =maxArmure;
            int[5] Classes =regenArmure;
            int[6] Classes =agilite;
            double[7] Classes =dommage;
            string[8] Classes =description;
            
            
            return new Acteur(nom, hp, maxHp, armure, maxArmure, regenArmure, agilite, dommage, description);
        }

        public Acteur GenererClasse()
        {
            int validation =0;
            
            while(validation!>1)
            {
                PoserQuestion();
                if (guerrier>magicien && guerrier>voleur)
                {
                    Acteur Guerrier = new Acteur(Classes);
                    validation++;   
                }

                else if(magicien>guerrier && magicien>voleur)
                {
                    Acteur Magicien = new Acteur(Classes[1]);
                    validation++;
                }

                else if (voleur>guerrier && voleur>magicien)
                {
                    Acteur Voleur = new Acteur(Classes[2]);
                    validation++;
                }

                else
                {
                    Console.WriteLine((Questions[4]));
                }
            }
            
            return Acteur;
        }

        public void PoserQuestion()
        {
            int choixJoueur =0;
            for (int i = 0; i < 3; i++)
            { 
                while(choixJoueur!=1 | choixJoueur!=2 | choixJoueur!=3)
                {
                    Console.WriteLine((Questions[i]));
                    int.TryParse(Console.ReadLine(),out choixJoueur);
                    Console.WriteLine("Veuillez répondre aux questions ci-dessous pour déterminez quelle classe vous allez être");
                    switch(choixJoueur)
                    {
                        case 1 :
                        guerrier++;
                        break;

                        case 2 :
                        magicien++;
                        break;

                        case 3 :
                        voleur++;
                        break;
                    }
                }   
            }
        }  
    }
}