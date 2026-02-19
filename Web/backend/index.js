import express from "express";
import mysql from "mysql2";
import cors from "cors";

const app = express();
app.use(cors());
app.use (express.json());

const db = mysql.createConnection({
    host: "localhost",
    user: "root",
    password: "",
    database: "nevnapok",
    port: 3307
});

function honapszamToNev(honapszam) {
    if (honapszam === null || honapszam === undefined) {
        return '';
    }
    switch (honapszam) {
        case 1:
            return 'január';
        case 2:
            return 'február';
        case 3:
            return 'március';
        case 4:
            return 'április';
        case 5:
            return 'május';
        case 6:
            return 'június';
        case 7:
            return 'július';
        case 8:
            return 'augusztus';
        case 9:
            return 'szeptember';
        case 10:
            return 'október';
        case 11:
            return 'november';
        case 12:
            return 'december';
        default:
            return '';
    }
}

app.get("/api/nevnapok", (req, res) => {
    const nap = req.query.nap || null;
    const nev = req.query.nev || null;

    if (!nap && !nev) {
        res.json({
            minta1: "/?nap=12-31",
            minta2: "/?nev=Szilveszter"
        });
        return;
    }

    if (nap !==null){
        const honap = nap.split("-")[0];
        const honapNev = honapszamToNev(parseInt(honap));
        const napSzam = nap.split("-")[1];
        const sql = `SELECT nev1, nev2 FROM nevnapok WHERE honap = ${honap} AND nap = ${napSzam}`;
        db.query(sql, (err, result) => {
            if (err) {
                res.json({ hiba: "nincs találat" });
                return;
            }
            if (result.length === 0) {
                res.json({ hiba: "nincs találat" });
                return;
            }
            res.json({
                datum: `${honapNev} ${napSzam}.`,
                nevnap1: result[0].nev1,
                nevnap2: result[0].nev2
            });
        });
    } 

    else if (nev !== null) {
          const sql = `SELECT honap, nap FROM nevnapok WHERE nev1 = '${nev}' OR nev2 = '${nev}'`;
          db.query(sql, (err, result) => {
                if (err) {
                 res.json({ hiba: "nincs találat" });
                 return;
                }
                if (result.length === 0) {
                 res.json({ hiba: "nincs találat" });
                 return;
                }
                const honapNev = honapszamToNev(result[0].honap);
                res.json({
                 datum: `${honapNev} ${result[0].nap}.`,
                 nevnap1: nev,
                 nevnap2: ''
                });
          });
     } else {
          res.json({ hiba: "nincs találat" });
     }
});


const port = 3000;
app.listen(port, () => {
    console.log(`Server is running http://localhost:${port}`);
});
