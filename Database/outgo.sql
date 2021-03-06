-- SQL Manager Lite for PostgreSQL 5.6.0.46253
-- ---------------------------------------
-- Host      : localhost
-- Database  : outgo
-- Version   : PostgreSQL 9.4.1, compiled by Visual C++ build 1800, 64-bit



CREATE SCHEMA trans AUTHORIZATION postgres;
SET check_function_bodies = false;
--
-- Structure for table User (OID = 32768) : 
--
SET search_path = trans, pg_catalog;
CREATE TABLE trans."User" (
    "Name" varchar NOT NULL,
    "UserID" integer DEFAULT nextval(('trans.user_userid_seq'::text)::regclass) NOT NULL,
    "Surname" varchar NOT NULL
)
WITH (oids = false);
ALTER TABLE ONLY trans."User" ALTER COLUMN "UserID" SET STATISTICS 1;
--
-- Structure for table Group (OID = 32784) : 
--
CREATE TABLE trans."Group" (
    "GroupID" integer DEFAULT nextval(('trans.group_groupid_seq'::text)::regclass) NOT NULL,
    "Name" varchar NOT NULL
)
WITH (oids = false);
ALTER TABLE ONLY trans."Group" ALTER COLUMN "GroupID" SET STATISTICS 1;
--
-- Structure for table UserGroup (OID = 32840) : 
--
CREATE TABLE trans."UserGroup" (
    "UserID" integer NOT NULL,
    "GroupID" integer NOT NULL,
    "UserGroupID" serial NOT NULL
)
WITH (oids = false);
--
-- Definition for sequence group_groupid_seq (OID = 32870) : 
--
CREATE SEQUENCE trans.group_groupid_seq
    START WITH 1
    INCREMENT BY 1
    MAXVALUE 2147483647
    NO MINVALUE
    CACHE 1;
--
-- Definition for sequence user_userid_seq (OID = 32885) : 
--
CREATE SEQUENCE trans.user_userid_seq
    START WITH 1
    INCREMENT BY 1
    MAXVALUE 2147483647
    NO MINVALUE
    CACHE 1;
--
-- Structure for table Payment (OID = 49238) : 
--
CREATE TABLE trans."Payment" (
    "PaymentID" serial NOT NULL,
    "UserID" integer NOT NULL,
    "GroupID" integer NOT NULL,
    "PaymentTypeID" integer NOT NULL,
    "Amount" numeric(19,2) NOT NULL,
    "Date" date NOT NULL
)
WITH (oids = false);
ALTER TABLE ONLY trans."Payment" ALTER COLUMN "PaymentID" SET STATISTICS 1;
--
-- Structure for table PaymentType (OID = 49268) : 
--
CREATE TABLE trans."PaymentType" (
    "PaymentTypeID" serial NOT NULL,
    "Description" varchar NOT NULL
)
WITH (oids = false);
--
-- Data for table trans."User" (OID = 32768) (LIMIT 0,5)
--
BEGIN;

INSERT INTO "User" ("Name", "UserID", "Surname")
VALUES ('Krzysztof', 12, 'Krzyskow');

INSERT INTO "User" ("Name", "UserID", "Surname")
VALUES ('Krzysztof', 1, 'Krzyskow');

INSERT INTO "User" ("Name", "UserID", "Surname")
VALUES ('Anna', 2, 'Zoladkiewicz');

INSERT INTO "User" ("Name", "UserID", "Surname")
VALUES ('John', 3, 'Doe');

INSERT INTO "User" ("Name", "UserID", "Surname")
VALUES ('John', 4, 'Doe');

COMMIT;
--
-- Data for table trans."Group" (OID = 32784) (LIMIT 0,2)
--
BEGIN;

INSERT INTO "Group" ("GroupID", "Name")
VALUES (1, 'Home');

INSERT INTO "Group" ("GroupID", "Name")
VALUES (2, 'Vacation');

COMMIT;
--
-- Data for table trans."UserGroup" (OID = 32840) (LIMIT 0,4)
--
BEGIN;

INSERT INTO "UserGroup" ("UserID", "GroupID", "UserGroupID")
VALUES (1, 2, 1);

INSERT INTO "UserGroup" ("UserID", "GroupID", "UserGroupID")
VALUES (1, 1, 2);

INSERT INTO "UserGroup" ("UserID", "GroupID", "UserGroupID")
VALUES (2, 1, 3);

INSERT INTO "UserGroup" ("UserID", "GroupID", "UserGroupID")
VALUES (4, 1, 4);

COMMIT;
--
-- Data for table trans."PaymentType" (OID = 49268) (LIMIT 0,8)
--
BEGIN;

INSERT INTO "PaymentType" ("PaymentTypeID", "Description")
VALUES (1, 'Home');

INSERT INTO "PaymentType" ("PaymentTypeID", "Description")
VALUES (2, 'Car');

INSERT INTO "PaymentType" ("PaymentTypeID", "Description")
VALUES (3, 'Fuel');

INSERT INTO "PaymentType" ("PaymentTypeID", "Description")
VALUES (4, 'Food');

INSERT INTO "PaymentType" ("PaymentTypeID", "Description")
VALUES (5, 'Cosmetics');

INSERT INTO "PaymentType" ("PaymentTypeID", "Description")
VALUES (6, 'Cats');

INSERT INTO "PaymentType" ("PaymentTypeID", "Description")
VALUES (7, 'Bills');

INSERT INTO "PaymentType" ("PaymentTypeID", "Description")
VALUES (8, 'Holidays');

COMMIT;
--
-- Definition for index UserGroup_idx (OID = 40972) : 
--
CREATE UNIQUE INDEX "UserGroup_idx" ON "UserGroup" USING btree ("GroupID", "UserID");
--
-- Definition for index Group_pkey (OID = 32872) : 
--
ALTER TABLE ONLY "Group"
    ADD CONSTRAINT "Group_pkey"
    PRIMARY KEY ("GroupID");
--
-- Definition for index UserGroup_Group_fkey (OID = 32874) : 
--
ALTER TABLE ONLY "UserGroup"
    ADD CONSTRAINT "UserGroup_Group_fkey"
    FOREIGN KEY ("GroupID") REFERENCES "Group"("GroupID");
--
-- Definition for index User_pkey (OID = 32887) : 
--
ALTER TABLE ONLY "User"
    ADD CONSTRAINT "User_pkey"
    PRIMARY KEY ("UserID");
--
-- Definition for index UserGroup_User_fkey (OID = 32889) : 
--
ALTER TABLE ONLY "UserGroup"
    ADD CONSTRAINT "UserGroup_User_fkey"
    FOREIGN KEY ("UserID") REFERENCES "User"("UserID");
--
-- Definition for index UserGroup_pkey (OID = 40970) : 
--
ALTER TABLE ONLY "UserGroup"
    ADD CONSTRAINT "UserGroup_pkey"
    PRIMARY KEY ("UserGroupID");
--
-- Definition for index Payment_pkey (OID = 49242) : 
--
ALTER TABLE ONLY "Payment"
    ADD CONSTRAINT "Payment_pkey"
    PRIMARY KEY ("PaymentID");
--
-- Definition for index Payment_Group_fkey (OID = 49244) : 
--
ALTER TABLE ONLY "Payment"
    ADD CONSTRAINT "Payment_Group_fkey"
    FOREIGN KEY ("GroupID") REFERENCES "Group"("GroupID");
--
-- Definition for index Payment_User_fkey (OID = 49249) : 
--
ALTER TABLE ONLY "Payment"
    ADD CONSTRAINT "Payment_User_fkey"
    FOREIGN KEY ("UserID") REFERENCES "User"("UserID");
--
-- Definition for index PaymentType_pkey (OID = 49275) : 
--
ALTER TABLE ONLY "PaymentType"
    ADD CONSTRAINT "PaymentType_pkey"
    PRIMARY KEY ("PaymentTypeID");
--
-- Definition for index Payment_Type_fk (OID = 49277) : 
--
ALTER TABLE ONLY "Payment"
    ADD CONSTRAINT "Payment_Type_fk"
    FOREIGN KEY ("PaymentTypeID") REFERENCES "PaymentType"("PaymentTypeID");
--
-- Data for sequence trans.group_groupid_seq (OID = 32870)
--
SELECT pg_catalog.setval('group_groupid_seq', 289, true);
--
-- Data for sequence trans.user_userid_seq (OID = 32885)
--
SELECT pg_catalog.setval('user_userid_seq', 348, true);
--
-- Data for sequence trans."UserGroup_UserGroupID_seq" (OID = 40960)
--
SELECT pg_catalog.setval('"UserGroup_UserGroupID_seq"', 72, true);
--
-- Data for sequence trans."Payment_PaymentID_seq" (OID = 49236)
--
SELECT pg_catalog.setval('"Payment_PaymentID_seq"', 164, true);
--
-- Data for sequence trans."PaymentType_PaymentTypeID_seq" (OID = 49266)
--
SELECT pg_catalog.setval('"PaymentType_PaymentTypeID_seq"', 8, true);
