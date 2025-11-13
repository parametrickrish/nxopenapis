            //parametrized constructor
            var cyl = new Cylinder(borediameter.ValueAsString, roddiameter.ValueAsString, strokelength.Value);
            cyl.ValidateRodDiameter();
            cyl.ValidateStroke();

            //non parametrized constructor
            Cylinder cyl = new Cylinder();
            cyl.BoreDiameter = borediameter.ValueAsString;
            cyl.RodDiameter = roddiameter.ValueAsString;
            cyl.StrokeLength = strokelength.Value;

            //without constructor
            Cylinder B26A005 = new Cylinder { };
            B26A005.BoreDiameter = borediameter.ValueAsString;
            B26A005.RodDiameter = roddiameter.ValueAsString;
            B26A005.StrokeLength = strokelength.Value;