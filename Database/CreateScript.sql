-- create scripts

CREATE TABLE trans."User" (
  "Name" VARCHAR NOT NULL,
  "UserID" INTEGER DEFAULT nextval('trans.user_userid_seq'::text::regclass) NOT NULL,
  "Surname" VARCHAR NOT NULL,
  CONSTRAINT "User_pkey" PRIMARY KEY("UserID")
) 
WITH (oids = false);

ALTER TABLE trans."User"
  ALTER COLUMN "UserID" SET STATISTICS 1;


CREATE TABLE trans."Group" (
  "GroupID" INTEGER DEFAULT nextval('trans.group_groupid_seq'::text::regclass) NOT NULL,
  "Name" VARCHAR NOT NULL,
  CONSTRAINT "Group_pkey" PRIMARY KEY("GroupID")
) 
WITH (oids = false);

ALTER TABLE trans."Group"
  ALTER COLUMN "GroupID" SET STATISTICS 1;

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

CREATE TABLE stat."PaymentType" (
  "PaymentTypeID" INTEGER DEFAULT nextval('stat.paymenttype_paymenttypeid_seq'::text::regclass) NOT NULL,
  "Description" VARCHAR NOT NULL,
  CONSTRAINT "PaymentType_pkey" PRIMARY KEY("PaymentTypeID")
) 
WITH (oids = false);

ALTER TABLE stat."PaymentType"
  ALTER COLUMN "PaymentTypeID" SET STATISTICS 1;


CREATE TABLE trans."Payment" (
  "PaymentID" INTEGER DEFAULT nextval('trans.payment_paymentid_seq'::text::regclass) NOT NULL,
  "UserID" INTEGER NOT NULL,
  "GroupID" INTEGER NOT NULL,
  "Amount" NUMERIC(19,2) NOT NULL,
  "Date" DATE NOT NULL,
  CONSTRAINT "Payment_pkey" PRIMARY KEY("PaymentID"),
  CONSTRAINT "Payment_Group_fkey" FOREIGN KEY ("GroupID")
    REFERENCES trans."Group"("GroupID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE,
  CONSTRAINT "Payment_User_fkey" FOREIGN KEY ("UserID")
    REFERENCES trans."User"("UserID")
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE
) 
WITH (oids = false);

ALTER TABLE trans."Payment"
  ALTER COLUMN "PaymentID" SET STATISTICS 1;

