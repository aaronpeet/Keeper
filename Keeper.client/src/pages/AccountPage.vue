<template>
  <div class="about flex-grow-1 container mt-3 p-0">
    <div class="row">
      <div class="col-md-3 rounded">
        <img :src="account.picture" alt="profile picture">
      </div>
      <div class="col-md-9">
        <h2>{{ account.name }}</h2>
        <h4>Keeps: {{ activeKeeps.length }}</h4>
        <h4>Vaults: {{ activeVaults.length }}</h4>
      </div>
    </div>
    <div class="row">
      <div class="col">
        <h1>VAULTS</h1>
        <button class="btn btn-success mt-3" data-toggle="modal" data-target="#createVaultModal" title="create a vault">
          Add Vault
        </button>
      </div>
      <CreateVaultModal />
      <div class="card-columns mt-3">
        <VaultsCard v-for="v in activeVaults" :key="v.id" :vault="v" />
      </div>
    </div>
    <div class="row">
      <div class="col">
        <h1>KEEPS</h1>
        <button class="btn btn-success mt-3" data-toggle="modal" data-target="#createKeepModal" title="create a keep">
          Add Keep
        </button>
      </div>
      <CreateKeepModal />
      <div class="card-columns mt-3">
        <ProfileKeepsCard v-for="k in activeKeeps" :key="k.id" :keep="k" />
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'
import Pop from '../utils/Notifier'
import { profilesService } from '../services/ProfilesService'
import { useRoute } from 'vue-router'
export default {
  setup() {
    const route = useRoute()
    onMounted(async() => {
      try {
        await profilesService.getProfileKeeps(route.params.id)
        await profilesService.getProfileVaults(route.params.id)
      } catch (error) {
        Pop.toast(error, 'error')
      }
    })
    return {
      account: computed(() => AppState.account),
      activeKeeps: computed(() => AppState.activeKeeps),
      activeVaults: computed(() => AppState.activeVaults)
    }
  }
}
</script>

<style scoped>

 </style>
