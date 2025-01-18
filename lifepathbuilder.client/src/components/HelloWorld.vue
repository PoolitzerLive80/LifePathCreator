<template>
    <div :class="{'dark-mode': isDarkMode, 'light-mode': !isDarkMode}">
      <header>
        <h1>Shadowrun 6th World - Charaktererstellung</h1>
        <p>Willkommen zur Shadowrun Lebenspfad Charaktererstellung!
        Hier kannst du deinen Shadowrun-Charakter Schritt für Schritt
        mit vorgefertigen Modulen erstellen.</p>
      </header>

      <!-- Scrollbares Panel mit bestehenden Charakternamen -->
      <div class="character-list-panel">
        <p>Bestehende Charaktere</p>
        <div class="character-list">
          <div v-if="post" class="content">
            <table>
              <thead>
                <tr>
                  <th>Date</th>
                  <th>Temp. (C)</th>
                  <th>Temp. (F)</th>
                  <th>Summary</th>
                </tr>
              </thead>
              <tbody>
                <tr v-for="forecast in post" :key="forecast.date">
                  <td>{{ forecast.date }}</td>
                  <td>{{ forecast.temperatureC }}</td>
                  <td>{{ forecast.temperatureF }}</td>
                  <td>{{ forecast.summary }}</td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
      </div>

      <!-- Button, um einen neuen Charakter zu erschaffen -->
      <div class="new-character-btn">
        <button @click="createNewCharacter">Neuen Charakter erschaffen</button>
      </div>

    </div>
</template>

<script lang="js">
  import { defineComponent } from 'vue';

  export default defineComponent({
    data() {
      return {
        loading: false,
        post: null
      };
    },
    async created() {
      // fetch the data when the view is created and the data is
      // already being observed
      await this.fetchData();
    },
    watch: {
      // call again the method if the route changes
      '$route': 'fetchData'
    },
    methods: {
      async fetchData() {
        this.post = null;
        this.loading = true;

        var response = await fetch('weatherforecast');
        if (response.ok) {
          this.post = await response.json();
          this.loading = false;
        }
      }
    },
  });
</script>

<style scoped>
  .character-creation {
    text-align: center;
    margin: 20px;
  }

  header {
    margin-bottom: 20px;
  }

  h1 {
    font-size: 2rem;
    font-weight: bold;
  }

  p {
    font-size: 1.1rem;
    margin: 10px 0;
  }

  .new-character-btn {
    margin: 20px;
  }

  button {
    padding: 10px 20px;
    font-size: 1.2rem;
    margin: 10px;
    cursor: pointer;
    background-color: #007bff;
    color: white;
    border: none;
    border-radius: 5px;
    transition: background-color 0.3s;
  }

    button:disabled {
      background-color: #c0c0c0;
      cursor: not-allowed;
    }


  .navigation button {
    padding: 10px 20px;
    margin: 20px 10px;
    background-color: #007bff;
    color: white;
    border: none;
    border-radius: 5px;
    font-size: 1.2rem;
  }

    .navigation button:disabled {
      background-color: #c0c0c0;
      cursor: not-allowed;
    }
</style>
