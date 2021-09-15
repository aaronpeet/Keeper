<template>
  <div class="about container-fluid mt-3">
    <div class="row">
      <div class="col-md-3 w-100 rounded">
        <img :src="account.picture" alt="profile picture">
      </div>
      <div class="col-md-9">
        <h2>{{ account.name }}</h2>
        <h4>Keeps: 24</h4>
        <h4>Vaults: 5</h4>
      </div>
    </div>
    <div class="row">
      <div class="col">
        <button class="btn btn-success">
          Add Vault
        </button>
      </div>
      <!-- <div class="col">
        <VaultsCard />
      </div> -->
    </div>
    <div class="row">
      <div class="col">
        <button class="btn btn-success mt-3">
          Add Keep
        </button>
      </div>
      <!-- <div class="cards-columns">
        <KeepsCard />
      </div> -->
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'
import Pop from '../utils/Notifier'
import { keepsService } from '../services/KeepsService'
import { vaultsService } from '../services/VaultsService'
import { useRoute } from 'vue-router'
export default {
  setup() {
    const route = useRoute()
    onMounted(async() => {
      try {
        await keepsService.getProfileKeeps(route.params.id)
        await vaultsService.getProfileVaults(route.params.id)
      } catch (error) {
        Pop.toast(error, 'error')
      }
    })
    return {
      account: computed(() => AppState.account)
    }
  }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>
