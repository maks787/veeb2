import { useEffect, useRef, useState } from 'react';
import './App.css';

function App() {
    const [tooted, setTooted] = useState([]);
    const [pakiautomaadid, setPakiautomaadid] = useState([]);
    const idRef = useRef();
    const nameRef = useRef();
    const priceRef = useRef();
    const isActiveRef = useRef();

    // Загрузка товаров
    useEffect(() => {
        fetch("http://localhost:5173/tooted")
            .then(res => res.json())
            .then(json => setTooted(json));
    }, []);

    // Загрузка пакетов
    useEffect(() => {
        fetch("http://localhost:5173/parcelmachine")
            .then(res => res.json())
            .then(json => setPakiautomaadid(json));
    }, []);

    function kustuta(index) {
        fetch("http://localhost:5173/tooted/kustuta/" + index, { method: "DELETE" })
            .then(res => res.json())
            .then(json => setTooted(json));
    }

    function lisa() {
        const uusToode = {
            id: Number(idRef.current.value),
            name: nameRef.current.value,
            price: Number(priceRef.current.value),
            isActive: isActiveRef.current.checked,
        };

        fetch("http://localhost:5173/Tooted/lisa", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(uusToode),
        })
            .then(res => res.json())
            .then(json => setTooted(json)); // Обновляем список товаров после добавления
    }

    function dollariteks() {
        const kurss = 1.1;
        fetch("http://localhost:5173/tooted/hind-dollaritesse/" + kurss, { method: "PATCH" })
            .then(res => res.json())
            .then(json => setTooted(json));
    }


    return (
        <div className="App">
            <label>ID</label> <br />
            <input ref={idRef} type="number" /> <br />
            <label>Nimi</label> <br />
            <input ref={nameRef} type="text" /> <br />
            <label>Hind</label> <br />
            <input ref={priceRef} type="number" /> <br />
            <label>Aktiivne</label> <br />
            <input ref={isActiveRef} type="checkbox" /> <br />
            <button onClick={lisa}>Lisa</button>

            <div className="table-container">
                <table className="table">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Nimi</th>
                            <th>Hind</th>
                            <th>Aktiivne</th>
                            <th>Tegevus</th>
                        </tr>
                    </thead>
                    <tbody>
                        {tooted.map((toode, index) => (
                            <tr key={toode.id}>
                                <td>{toode.id}</td>
                                <td>{toode.name}</td>
                                <td>{toode.price.toFixed(2)}</td>
                                <td>{toode.isActive ? 'Jah' : 'Ei'}</td>
                                <td><button onClick={() => kustuta(index)}>Kustuta</button></td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>

            <button onClick={dollariteks}>Muuda dollariteks</button>

            <div>
                <select>
                    {pakiautomaadid.map(automaat => (
                        <option key={automaat.ID}>
                            {automaat.NAME}
                        </option>
                    ))}
                </select>
            </div>
        </div>
    );
}

export default App;
