BEGIN TRANSACTION;
CREATE TABLE "Recipes" (
  "Id" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, "DifficulteRecette" bigint NOT NULL
, "TempsPreparation" bigint NOT NULL
);
CREATE TABLE "Ingredients" (
  "Id" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, "Nom" text NOT NULL
, "DatePeremption" bigint NOT NULL
, "UniteMesure" bigint NOT NULL
);
COMMIT;

