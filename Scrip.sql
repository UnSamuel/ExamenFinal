-- This script was generated by the ERD tool in pgAdmin 4.
-- Please log an issue at https://redmine.postgresql.org/projects/pgadmin4/issues/new if you find any bugs, including reproduction steps.
BEGIN;


CREATE TABLE IF NOT EXISTS public.aviones
(
    avionid integer NOT NULL DEFAULT nextval('aviones_avionid_seq'::regclass),
    numero integer,
    modelo character varying(255) COLLATE pg_catalog."default",
    peso integer,
    capacidad integer,
    hangarid integer,
    CONSTRAINT aviones_pkey PRIMARY KEY (avionid)
);

CREATE TABLE IF NOT EXISTS public.avionespilotos
(
    avionid integer NOT NULL,
    pilotoid integer NOT NULL,
    CONSTRAINT avionespilotos_pkey PRIMARY KEY (avionid, pilotoid)
);

CREATE TABLE IF NOT EXISTS public.hangares
(
    hangarid integer NOT NULL DEFAULT nextval('hangares_hangarid_seq'::regclass),
    numero integer,
    capacidad integer,
    localizacion character varying(255) COLLATE pg_catalog."default",
    CONSTRAINT hangares_pkey PRIMARY KEY (hangarid)
);

CREATE TABLE IF NOT EXISTS public.pilotos
(
    pilotoid integer NOT NULL DEFAULT nextval('pilotos_pilotoid_seq'::regclass),
    numerolicencia integer,
    restricciones character varying(255) COLLATE pg_catalog."default",
    salario numeric(10, 2),
    turno character varying(50) COLLATE pg_catalog."default",
    CONSTRAINT pilotos_pkey PRIMARY KEY (pilotoid)
);

ALTER TABLE IF EXISTS public.aviones
    ADD CONSTRAINT aviones_hangarid_fkey FOREIGN KEY (hangarid)
    REFERENCES public.hangares (hangarid) MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION;


ALTER TABLE IF EXISTS public.avionespilotos
    ADD CONSTRAINT avionespilotos_avionid_fkey FOREIGN KEY (avionid)
    REFERENCES public.aviones (avionid) MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION;


ALTER TABLE IF EXISTS public.avionespilotos
    ADD CONSTRAINT avionespilotos_pilotoid_fkey FOREIGN KEY (pilotoid)
    REFERENCES public.pilotos (pilotoid) MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION;

END;