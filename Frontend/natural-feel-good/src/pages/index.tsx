import { LanguageSwitcher } from '../components';
import styles from '../styles/Home.module.css';

const Home = () => {
    return (
        <div className={styles.container}>
            <header className={styles.header}>
                <h1>Welcome to Natural Feel Good</h1>
                <LanguageSwitcher />
            </header>
            <main className={styles.main}>
                <p>Your journey to wellness starts here.</p>
            </main>
            <footer className={styles.footer}>
                <p>&copy; {new Date().getFullYear()} Natural Feel Good. All rights reserved.</p>
            </footer>
        </div>
    );
};

export default Home;