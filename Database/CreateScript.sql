-- create scripts

CREATE TABLE trans."User"
(
  "Name" VARCHAR NOT NULL,
  "UserID" INTEGER NOT NULL,
  "Surname" VARCHAR NOT NULL,
  CONSTRAINT "User_pkey" PRIMARY KEY("UserID")
)

CREATE TABLE trans."Group"
(
	"GroupID" INTEGER NOT NULL,
    "Name" VARCHAR NOT NULL,
    CONSTRAINT "Group_pkey" PRIMARY KEY ("GroupID")
)

CREATE TABLE trans."UserGroup" (
  "UserID" INTEGER NOT NULL,
  "GroupID" INTEGER NOT NULL,
  CONSTRAINT "UserGroup_pkey" PRIMARY KEY("UserID", "GroupID"),
  CONSTRAINT "UserGroup_User_fkey" FOREIGN KEY ("UserID")
    REFERENCES trans."User"("UserID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE,
  CONSTRAINT "UserGroup_Group_fkey" FOREIGN KEY ("GroupID")
    REFERENCES trans."Group"("GroupID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE
)

CREATE TABLE stat."PaymentType"
(
	"PaymentTypeID" INTEGER NOT NULL,
    "Description" VARCHAR NOT NULL,
    CONSTRAINT "PaymentType_pkey" PRIMARY KEY ("PaymentTypeID")
)

CREATE TABLE trans."Payment"
(
	"PaymentID" INTEGER NOT NULL,
	"UserID" INTEGER NOT NULL,
 	"GroupID" INTEGER NOT NULL,
    "Amount" DECIMAL(19,2) NOT NULL,
    "Date" DATE NOT NULL,
  CONSTRAINT "Payment_pkey" PRIMARY KEY("PaymentID"),
  CONSTRAINT "Payment_User_fkey" FOREIGN KEY ("UserID")
    REFERENCES trans."User"("UserID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE,
  CONSTRAINT "Payment_Group_fkey" FOREIGN KEY ("GroupID")
    REFERENCES trans."Group"("GroupID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE
)

