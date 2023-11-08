
--Mockaroo servisini kullanarak 50 adet veri ekleyelim-

INSERT INTO employee (name, birthday, email) VALUES
('murat', '1992-09-12', 'murat@sun.com'),
('Bern', '1995-09-08', 'bseater1@oakley.com'),
('Frederik', '1994-05-03', 'fcareless2@blogger.com'),
('Meryl', '1994-10-08', 'mocuolahan3@infoseek.co.jp'),
('Sven', '2001-08-24', 'srodda4@ucoz.ru'),
('Benji', '2003-02-08', 'ballwright5@ihg.com'),
('Starr', '1982-01-02', 'srumford6@elpais.com'),
('Heindrick', '1996-07-06', 'hmathiasen7@diigo.com'),
('Lorrie', '1991-01-27', 'lwehnerr8@epa.gov'),
('Neils', '1997-03-21', 'nsowrey9@tinyurl.com'),
('Michell', '1994-02-20', 'mjerreda@i2i.jp'),
('Morley', '1983-12-09', 'mextenceb@topsy.com'),
('Tedda', '1990-02-25', 'tgiblinc@google.co.jp'),
('Web', '1989-06-21', 'wcousind@free.fr'),
('Devy', '2000-04-12', 'dllelwelne@constantcontact.com'),
('Darci', '1983-01-27', 'dlebournf@smh.com.au'),
('Adolpho', '2000-01-17', 'alutherg@theguardian.com'),
('Jo', '1988-12-03', 'jtreadwayh@thetimes.co.uk'),
('Aveline', '1990-06-18', 'astapforthi@imageshack.us'),
('Evaleen', '1991-12-08', 'etosdevinj@google.cn'),
('Iago', '2000-07-30', 'ibertomeuk@domainmarket.com'),
('Wit', '1996-05-26', 'wosullivanl@wiley.com'),
('Tad', '1989-06-05', 'tnowerm@squarespace.com'),
('Coop', '2002-12-23', 'cchazerandn@alibaba.com'),
('Bordie', '2000-09-02', 'blesurfo@ucla.edu'),
('Brittani', '1992-03-30', 'bbravingtonp@cafepress.com'),
('Obediah', '1996-01-02', 'oparramoreq@diigo.com'),
('Cindee', '1991-09-20', 'csharplessr@g.co'),
('Vernice', '2000-03-13', 'vskoates@over-blog.com'),
('Toby', '1999-09-26', 'taront@blogtalkradio.com'),
('Suki', '1996-05-22', 'sslaffordu@typepad.com'),
('Cathe', '1994-12-15', 'cnormavillv@example.com'),
('Ardeen', '1996-08-11', 'atettersellw@craigslist.org'),
('Babb', '2002-04-04', 'bsellarsx@fotki.com'),
('Wilow', '1991-06-10', 'wguilfordy@elpais.com'),
('Abeu', '2001-02-02', 'abennedickz@lulu.com'),
('Marketa', '1992-06-07', 'mcrowest10@xing.com'),
('Lawton', '2003-07-27', 'lcawston11@blinklist.com'),
('Renault', '1986-07-17', 'rhellwig12@google.nl'),
('Kimball', '1994-09-29', 'kalesio13@nsw.gov.au'),
('Lindi', '1981-05-15', 'lraynor14@bbc.co.uk'),
('Jedediah', '1995-03-15', 'jblakeley15@netvibes.com'),
('Patty', '1983-01-18', 'pmicklewicz16@howstuffworks.com'),
('Luciano', '1986-07-19', 'lfilewood17@example.com'),
('Marja', '1995-10-09', 'mpimer18@fastcompany.com'),
('Amabel', '1992-05-26', 'aplunkett19@ft.com'),
('Reinald', '1998-06-23', 'rberget1a@sitemeter.com'),
('Cati', '1995-01-20', 'cleivesley1b@rediff.com'),
('Ursola', '2000-01-17', 'umullen1c@eepurl.com'),
('Debbie', '2002-07-29', 'dsirey1d@hp.com');

--3 adet update eklenmesi-
UPDATE employee 
SET name = 'Murat',
    birthday = '2000-06-15',
    email = 'cagri.ozden98@gmail.com'
WHERE id =1

UPDATE employee
SET name = 'Cengiz',
    birthday = '1994-07-12',
    email = 'cengizzdal@gmail.com'
WHERE id = 2

UPDATE employee
SET name = 'Abdullah',
    birthday = '1991-04-13',
    email = 'abdullahhdal@gmail.com'
WHERE id = 3

--3 adet DELETE işlemi yapalım

DELETE FROM employee
WHERE id in(13,22,32)