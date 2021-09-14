<template>
  <div class="home flex-grow-1 container p-0">
    <div class="card-columns">
      <KeepsCard v-for="k in keeps" :key="k.id" :keep="k" />
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from '@vue/runtime-core'
import Pop from '../utils/Notifier'
import { AppState } from '../AppState'
import { keepsService } from '../services/KeepsService'
export default {
  setup() {
    onMounted(async() => {
      try {
        await keepsService.getAllKeeps()
      } catch (error) {
        Pop.toast('Something is had gone wrong', 'error')
      }
    })
    return {
      keeps: computed(() => AppState.keeps)
    }
  }
}
</script>

<style scoped lang="scss">

</style>
