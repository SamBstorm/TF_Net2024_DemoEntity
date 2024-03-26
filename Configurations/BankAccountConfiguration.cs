using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TF_Net2024_DemoEntity.Entities;

namespace TF_Net2024_DemoEntity.Configurations
{
    internal class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.ToTable("BankAccounts");

            builder.HasKey(b => b.AccountNumber);

            builder.Property(b => b.AccountNumber)
                .HasColumnType("CHAR")
                .HasMaxLength(16);

            builder.Property(b => b.BankName)
                .HasColumnName("Bank_name")
                .HasMaxLength(16)
                .IsRequired();

            builder.Property(b => b.Amount)
                .HasColumnType("MONEY")
                .HasDefaultValue(0);

            builder.HasOne(b => b.Titular)          //Dans notre config de BankAccount,
                                                    //je spécifie à quel Type il est lié grâce au Type de sa propriété
                                                    //HasOne() défini une relation One-to-... avec une autre entité
                .WithOne(p => p.BankAccount)        //Permet de définir la relation 'retour'
                                                    //WithOne() défini la fin de relation ...-to-One
                .HasForeignKey<BankAccount>(b => b.TitularId)  //HasForeignKey<T>() permet de définir quel objet
                                                               //de la relation obtient la foreignKey avec le <T>
                .OnDelete(DeleteBehavior.Restrict)  //OnDelete permet de définir l'action de suppression quand l'entité liée
                                                    //(ici le titulaire de type Person) est supprimé
                                                    //Cascade : Si le titulaire est supprimé, le compte aussi
                                                    //SetNull : Si le titulaire est supprimé, définir la FK en NULL (si possible)
                                                    //ClientSetNull : Si le titulaire est supprimé,
                                                    //              définir la FK en NULL du côté application, pas dans la DB
                                                    //              (si possible)
                                                    //              Mais reprends le comportement DB une fois le context rechargé
                                                    //Restrict : Si le titulaire est supprimé, et qu'une relation existe,
                                                    //           protège le titulaire de la suppression
                .IsRequired();

        }
    }
}
