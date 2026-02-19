import {Routes, Route, Link} from 'react-router-dom';

const Menu = () => {
    return (
        <nav>
            <ul>
                <li><Link to="/">Home</Link></li>
                <li><Link to="/nevnap">Névnap</Link></li>
                <li><Link to="/szulinap">Születésnap</Link></li>
                <li><Link to="/kapcsolat">Kapcsolat</Link></li>
            </ul>
        </nav>
    );
}

export default Menu;