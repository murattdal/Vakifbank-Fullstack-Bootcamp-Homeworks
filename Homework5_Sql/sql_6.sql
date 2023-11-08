--(soru1)
SELECT AVG(rental_rate) FROM film;
--(soru2)
SELECT COUNT(*) FROM film WHERE title LIKE 'C%';
--(soru3)
SELECT MAX(length) FROM film WHERE rental_rate=0.99;
--(soru4)
SELECT COUNT(DISTINCT replacement_cost) FROM film WHERE length>140;