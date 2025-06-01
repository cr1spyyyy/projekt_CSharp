--
-- PostgreSQL database dump
--

-- Dumped from database version 17.4
-- Dumped by pg_dump version 17.4

-- Started on 2025-06-01 22:16:03

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 218 (class 1259 OID 16433)
-- Name: Kursy; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Kursy" (
    id integer NOT NULL,
    nazwa character varying(255) NOT NULL,
    opis text,
    datarozpoczecia date NOT NULL,
    datazakonczenia date,
    maksymalnaliczbauczestnikow integer NOT NULL,
    prowadzacy character varying(150),
    cena numeric(10,2) NOT NULL,
    CONSTRAINT kursy_cena_check CHECK ((cena >= (0)::numeric)),
    CONSTRAINT kursy_maksymalnaliczbauczestnikow_check CHECK ((maksymalnaliczbauczestnikow > 0))
);


ALTER TABLE public."Kursy" OWNER TO postgres;

--
-- TOC entry 220 (class 1259 OID 16444)
-- Name: Uczestnicy; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Uczestnicy" (
    id integer NOT NULL,
    imie character varying(100) NOT NULL,
    nazwisko character varying(150) NOT NULL,
    email character varying(255) NOT NULL,
    numertelefonu character varying(20),
    dataurodzenia date
);


ALTER TABLE public."Uczestnicy" OWNER TO postgres;

--
-- TOC entry 222 (class 1259 OID 16455)
-- Name: Zapisy; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Zapisy" (
    id integer NOT NULL,
    kursid integer NOT NULL,
    uczestnikid integer NOT NULL,
    datazapisu timestamp without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL
);


ALTER TABLE public."Zapisy" OWNER TO postgres;

--
-- TOC entry 217 (class 1259 OID 16432)
-- Name: kursy_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.kursy_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.kursy_id_seq OWNER TO postgres;

--
-- TOC entry 4926 (class 0 OID 0)
-- Dependencies: 217
-- Name: kursy_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.kursy_id_seq OWNED BY public."Kursy".id;


--
-- TOC entry 219 (class 1259 OID 16443)
-- Name: uczestnicy_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.uczestnicy_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.uczestnicy_id_seq OWNER TO postgres;

--
-- TOC entry 4927 (class 0 OID 0)
-- Dependencies: 219
-- Name: uczestnicy_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.uczestnicy_id_seq OWNED BY public."Uczestnicy".id;


--
-- TOC entry 221 (class 1259 OID 16454)
-- Name: zapisy_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.zapisy_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.zapisy_id_seq OWNER TO postgres;

--
-- TOC entry 4928 (class 0 OID 0)
-- Dependencies: 221
-- Name: zapisy_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.zapisy_id_seq OWNED BY public."Zapisy".id;


--
-- TOC entry 4752 (class 2604 OID 16436)
-- Name: Kursy id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Kursy" ALTER COLUMN id SET DEFAULT nextval('public.kursy_id_seq'::regclass);


--
-- TOC entry 4753 (class 2604 OID 16447)
-- Name: Uczestnicy id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Uczestnicy" ALTER COLUMN id SET DEFAULT nextval('public.uczestnicy_id_seq'::regclass);


--
-- TOC entry 4754 (class 2604 OID 16458)
-- Name: Zapisy id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Zapisy" ALTER COLUMN id SET DEFAULT nextval('public.zapisy_id_seq'::regclass);


--
-- TOC entry 4916 (class 0 OID 16433)
-- Dependencies: 218
-- Data for Name: Kursy; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Kursy" (id, nazwa, opis, datarozpoczecia, datazakonczenia, maksymalnaliczbauczestnikow, prowadzacy, cena) FROM stdin;
2	Programowanie w Pythonie	Kurs od podstaw do zaawansowanych technik	2025-07-10	2025-08-20	25	Anna Nowak	699.00
1	Kurs C# dla początkujących	Podstawy języka C#	2025-06-01	2025-08-20	20	Anna Nowak	499.99
3	Front-End	HTML, CSS, JavaScript i React	2025-08-02	2025-09-19	40	Marek Wiśniewski	700.00
9	dobry	Javka skibidi\r\nmareczek	2025-05-14	2025-05-30	25	Maciej musial	200.00
6	Kurs sigmy	sigma sigma boy	2025-05-26	2025-05-29	5	Wojtek krul	30.00
\.


--
-- TOC entry 4918 (class 0 OID 16444)
-- Dependencies: 220
-- Data for Name: Uczestnicy; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Uczestnicy" (id, imie, nazwisko, email, numertelefonu, dataurodzenia) FROM stdin;
3	Piotr	Nowak	piotr.nowak@example.com	501765432	1985-11-05
4	Zofia	Wiśniewska	zofia.wisniewska@example.com	987654321	2003-12-01
6	Maciek	Skibidi	maciek@example.com	234980345	2002-03-01
5	Tomasz	Dąbrowski	tomasz.dabrowski@example.com	789654321	1999-07-23
1	Jann	Kowalski	jan.kowalski@example.com	123456789	1999-10-11
7	sergiej	run skibidi	rej@rj.com	123432031	2004-10-12
2	Anna	Kowal	anna.kowalczyk@example.com	000000000	1990-03-12
\.


--
-- TOC entry 4920 (class 0 OID 16455)
-- Dependencies: 222
-- Data for Name: Zapisy; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Zapisy" (id, kursid, uczestnikid, datazapisu) FROM stdin;
1	1	1	2025-05-10 18:46:08.153246
2	2	2	2025-05-11 10:00:00
4	1	3	2025-05-12 09:30:00
5	2	4	2025-05-12 12:00:00
8	6	7	2025-05-14 19:21:32.730506
9	3	5	2025-05-14 19:23:07.768952
10	9	2	2025-05-16 13:59:57.057232
11	9	5	2025-05-16 14:41:52.199771
12	3	7	2025-05-16 14:42:21.859499
14	6	3	2025-05-16 15:41:51.826965
15	9	1	2025-05-16 16:53:00.028054
17	1	6	2025-05-16 17:00:32.878436
18	3	6	2025-05-16 17:00:42.89969
19	9	6	2025-05-16 17:00:51.185368
20	3	1	2025-05-16 17:01:21.988932
21	9	3	2025-05-16 18:57:56.665179
\.


--
-- TOC entry 4929 (class 0 OID 0)
-- Dependencies: 217
-- Name: kursy_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.kursy_id_seq', 10, true);


--
-- TOC entry 4930 (class 0 OID 0)
-- Dependencies: 219
-- Name: uczestnicy_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.uczestnicy_id_seq', 8, true);


--
-- TOC entry 4931 (class 0 OID 0)
-- Dependencies: 221
-- Name: zapisy_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.zapisy_id_seq', 21, true);


--
-- TOC entry 4759 (class 2606 OID 16442)
-- Name: Kursy kursy_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Kursy"
    ADD CONSTRAINT kursy_pkey PRIMARY KEY (id);


--
-- TOC entry 4761 (class 2606 OID 16453)
-- Name: Uczestnicy uczestnicy_email_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Uczestnicy"
    ADD CONSTRAINT uczestnicy_email_key UNIQUE (email);


--
-- TOC entry 4763 (class 2606 OID 16451)
-- Name: Uczestnicy uczestnicy_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Uczestnicy"
    ADD CONSTRAINT uczestnicy_pkey PRIMARY KEY (id);


--
-- TOC entry 4765 (class 2606 OID 16463)
-- Name: Zapisy unique_kurs_uczestnik; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Zapisy"
    ADD CONSTRAINT unique_kurs_uczestnik UNIQUE (kursid, uczestnikid);


--
-- TOC entry 4767 (class 2606 OID 16461)
-- Name: Zapisy zapisy_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Zapisy"
    ADD CONSTRAINT zapisy_pkey PRIMARY KEY (id);


--
-- TOC entry 4768 (class 2606 OID 16464)
-- Name: Zapisy fk_kurs; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Zapisy"
    ADD CONSTRAINT fk_kurs FOREIGN KEY (kursid) REFERENCES public."Kursy"(id) ON DELETE CASCADE;


--
-- TOC entry 4769 (class 2606 OID 16469)
-- Name: Zapisy fk_uczestnik; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Zapisy"
    ADD CONSTRAINT fk_uczestnik FOREIGN KEY (uczestnikid) REFERENCES public."Uczestnicy"(id) ON DELETE CASCADE;


-- Completed on 2025-06-01 22:16:03

--
-- PostgreSQL database dump complete
--

