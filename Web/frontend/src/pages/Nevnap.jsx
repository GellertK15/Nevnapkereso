import { useState } from "react";
import axios from "axios";

const Nevnap = () => {
    const [nevnap, setNevnap] = useState(null);
    const [month, setMonth] = useState("");
    const [day, setDay] = useState("");

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            if (month === '' || day === '') {
                setNevnap(null);
                alert('Kérjük, adja meg a hónapot és a napot!');
                return;
            }
            const response = await axios.get(`http://localhost:3000/api/nevnap/?nap=${month}-${day}`);
            console.log(response.data);
            setNevnap(response.data);
        } catch (error) {
            console.error('Hiba a névnapok lekérésekor:', error);
            setNevnap(null);
        }
    };

    return (
        <div>
            <h1>Névnap keresése</h1>
            <form onSubmit={handleSubmit}>
                <label>
                    Hónap:
                    <input
                         type="number"
                         className="form-control"
                         id="month"
                         placeholder="1-12"
                         min="1"
                         max="12"
                         value={month}
                         onChange={(e) => setMonth(e.target.value)}
                         required
                    />
                </label>
                <br />
                <label>
                    Nap:
                    <input
                        ttype="number"
                        className="form-control"
                        id="day"
                        placeholder="1-31"
                        min="1"
                        max="31"
                        value={day}
                        onChange={(e) => setDay(e.target.value)}
                        required
                    />
                </label>
                <br />
                <button type="submit">Keresés</button>
            </form>
            {nevnap && (
                <div>
                    <h2>Névnap:</h2>
                    <p>{nevnap.datum}</p>
                    <p>{nevnap.nevnap1}</p>
                    {nevnap.nevnap2 && <p>{nevnap.nevnap2}</p>}
                </div>
            )}
        </div>
    )
}

export default Nevnap;