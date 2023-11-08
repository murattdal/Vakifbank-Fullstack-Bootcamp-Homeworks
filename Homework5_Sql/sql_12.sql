--(soru1)
SELECT COUNT(*) FROM film WHERE length > (SELECT AVG(length) FROM film);
--(soru2)
SELECT COUNT(*) FROM film WHERE rental_rate = (SELECT MAX(rental_rate) FROM film);
--(soru3)
SELECT * FROM film WHERE rental_rate = (SELECT MIN(rental_rate) FROM film)
AND replacement_cost = (SELECT MIN(replacement_cost) FROM film);
--(soru4)
SELECT customer_id, COUNT(*) AS num_of_transactions FROM payment
GROUP BY customer_id
ORDER BY num_of_transactions DESC
LIMIT 12;

