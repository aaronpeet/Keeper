<template>
  <div class="container-fluid mt-3 my-3">
    <h1>{{ activeVault.name }}</h1>
    <p>Keeps: {{ vaultKeeps.length }}</p>
  </div>
</template>

<script>
import { computed, onMounted } from '@vue/runtime-core'
import { useRoute } from 'vue-router'
import Pop from '../utils/Notifier'
import { AppState } from '../AppState'
import { vaultsService } from '../services/VaultsService'
export default {
  setup() {
    const route = useRoute()
    onMounted(async() => {
      try {
        await vaultsService.getVaultById(route.params.id)
        await vaultsService.getVaultKeeps(route.params.id)
      } catch (error) {
        Pop.toast(error, 'error')
      }
    })
    return {
      vaultKeeps: computed(() => AppState.activeVaultKeeps),
      activeVault: computed(() => AppState.activeVault)
    }
  }
}
</script>

<style lang="scss" scoped>

</style>
