            //parametrized constructor
            var cyl = new Cylinder(borediameter.ValueAsString, roddiameter.ValueAsString, strokelength.Value);
            cyl.ValidateRodDiameter();
            cyl.ValidateStroke();

            //non parametrized constructor
            Cylinder cyl = new Cylinder();
            cyl.BoreDiameter = borediameter.ValueAsString;
            cyl.RodDiameter = roddiameter.ValueAsString;
            cyl.StrokeLength = strokelength.Value;

            //call the functions(methods) of the Cylinder class on
            //that object simply using the dot operator (.), just like this:
            cyl.ValidateRodDiameter();
            cyl.ValidateStroke();


            //without constructor
            Cylinder B26A005 = new Cylinder { };
            B26A005.BoreDiameter = borediameter.ValueAsString;
            B26A005.RodDiameter = roddiameter.ValueAsString;
            B26A005.StrokeLength = strokelength.Value;

            //call the functions (methods) of the Cylinder class on the B26A005 object
            //using the dot operator, exactly the same way as with any object instance.
            B26A005.ValidateRodDiameter();
            B26A005.ValidateStroke();