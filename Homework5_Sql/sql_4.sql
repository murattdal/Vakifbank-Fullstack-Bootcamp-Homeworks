--(soru1)
SELECT DISTINCT replacement_cost FROM film;

--(soru1)
SELECT COUNT(DISTINCT replacement_cost) FROM film;

--(soru2)
SELECT COUNT(*) FROM film WHERE title LIKE 'T%' AND rating='G';

--(soru3)
SELECT COUNT(*) FROM country WHERE country LIKE '_____';

--(soru4)
SELECT COUNT(*) FROM city WHERE city ILIKE '%R';