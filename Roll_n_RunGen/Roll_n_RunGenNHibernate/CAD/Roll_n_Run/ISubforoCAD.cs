
using System;
using Roll_n_RunGenNHibernate.EN.Roll_n_Run;

namespace Roll_n_RunGenNHibernate.CAD.Roll_n_Run
{
public partial interface ISubforoCAD
{
SubforoEN ReadOIDDefault (int id
                          );

void ModifyDefault (SubforoEN subforo);

System.Collections.Generic.IList<SubforoEN> ReadAllDefault (int first, int size);



int New_ (SubforoEN subforo);

void Modify (SubforoEN subforo);


void Destroy (int id
              );


SubforoEN ReadOID (int id
                   );


System.Collections.Generic.IList<SubforoEN> ReadAll (int first, int size);
}
}
